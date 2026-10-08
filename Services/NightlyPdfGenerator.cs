using Cronos;
using DinkToPdf;
using MedicalRecord.Service;
using MedicalRecordApi.Data;
using MedicalRecordApi.Data;
using MedicalRecordApi.Helpers;
using MedicalRecordApi.Interface;
using MedicalRecordApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NuGet.ProjectModel;

namespace MedicalRecordApi.Service
{
    public class NightlyPdfGenerator : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider; 
        private readonly CronExpression _cronExpression;
        private readonly TimeZoneInfo _timeZone;
        private readonly IServiceProvider _provider;
        private readonly string _pdfOutputPath;


        public NightlyPdfGenerator(IServiceProvider serviceProvider, IServiceProvider provider,IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _cronExpression = CronExpression.Parse("0 16 7 * * *", CronFormat.IncludeSeconds); 
            _timeZone = TimeZoneInfo.Local;  
            _provider = provider;
            _pdfOutputPath = configuration["PdfStorage:OutputPath"]
       ?? throw new InvalidOperationException("PdfStorage:OutputPath is not configured");
        } 

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            { 
                var next = _cronExpression.GetNextOccurrence(DateTimeOffset.Now, _timeZone);
                if (!next.HasValue)
                    break;

                var delay = next.Value - DateTimeOffset.Now;
                if (delay.TotalMilliseconds > 0)
                    await Task.Delay(delay, stoppingToken); 

                try
                {
                    await GenerateDailyPdfs();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error generating PDFs: {ex}");
                }
            }
        }

        private async Task GenerateDailyPdfs()
        {
            using var scope = _serviceProvider.CreateScope();

            var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var renderer = scope.ServiceProvider.GetRequiredService<IRazorViewRenderer>();
            using var scopee = _serviceProvider.CreateScope();
            var env = scopee.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
            var converter = new SynchronizedConverter(new PdfTools());
            //var pdfService = new PdfService(converter, env);
            var pdfService = new ChromePdfService();

            var pdfDate = DateTime.Today.AddDays(-1).Date;

            
            var preOpRecords = await _context.EndoscopyProcedureRecords
                .Where(x => x.ProcedureDate < DateTime.Now && x.PostOp == true && x.PdfFilePath == null)
                .ToListAsync();

            var records = new List<BothEndocopyForm>();

            foreach (var pre in preOpRecords)
            {
                var postOp = await _context.EndoscopyPostProcedureRecords
                    .Include(r => r.Aldrete)
                    .Include(r => r.MonitoringRows)
                    .Include(r => r.NursingMedications)
                    .FirstOrDefaultAsync(r => r.EndoscopyProcedureRecordId == pre.Id);

                records.Add(new BothEndocopyForm 
                {
                    PreOp = pre,
                    PostOp = postOp
                });
            }

            var logFolder = Path.Combine(env.ContentRootPath, "logs");
            if (!Directory.Exists(logFolder)) Directory.CreateDirectory(logFolder);

            var logFile = Path.Combine(logFolder, $"PDF_LOG_{DateTime.Today:yyyy-MM-dd}.txt");

            await WriteLog(logFile, "=== PDF Generation Started ===");

            //var folder = Path.Combine(env.WebRootPath, "pdfs");
            //if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            var folder = _pdfOutputPath;
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            var del = await _context.EndoscopyProcedureRecords
                        .Where(m => m.PostOp == true
                                 && m.PdfFilePath != null
                                 && m.BotJobDone == false)
                        .GroupBy(m => m.CreatedAt.Date)
                        .Select(g => g.Key)
                        .OrderBy(d => d)
                        .ToListAsync();

           // await DeleteOldFiles(pdfDate, logFile, folder);
            foreach (var record in records)
            {
                try
                {
                    string patientname = RemoveBacktick(record.PreOp?.PatientName);
                    
                    
                    var cssPath = Path.Combine(env.WebRootPath, "css", "bootstrap.min.css");
                    var bootstrapCss = await File.ReadAllTextAsync(cssPath);

                    string html = await renderer.RenderViewToStringAsync(
                        "/Views/EndoscopyProcedureRecords/PdfTemplate.cshtml",
                        record
                    );

                    html = $"<style>{bootstrapCss}</style>" + html;

                    var pdfBytes =  await pdfService.GeneratePdfAsync(html);

                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string safeName = $"{SanitizeFileName(patientname)}_{SanitizeFileName(record.PreOp.AccNo)}_{timestamp}.pdf";
                    var path = Path.Combine(folder, $"EndoscopyRecord_{safeName}");

                    await File.WriteAllBytesAsync(path, pdfBytes);

                    
                    record.PreOp.PdfFilePath = path;
                    _context.Update(record.PreOp);
                    await _context.SaveChangesAsync();

                    await WriteLog(logFile, $"SUCCESS: PDF generated for {patientname} → {path}");
                }
                catch (Exception ex)
                {
                    await WriteLog(logFile, $"ERROR: {RemoveBacktick(record.PreOp?.PatientName)} — {ex.Message}");
                }
            }

            await WriteLog(logFile, "=== PDF Generation Completed ===");
        }

        private async Task DeleteOldFiles(DateTime cutoffDate, string logFile ,string folder)
        {  
            var pdfFiles = Directory.GetFiles(folder, "*.pdf");

            foreach (var file in pdfFiles)
            {
                var created = File.GetCreationTime(file);

                if (created < cutoffDate)
                {
                    try
                    {
                        File.Delete(file);
                        await WriteLog(logFile, $"DELETED OLD PDF: {file} (Created: {created})");
                    }
                    catch (Exception ex)
                    {
                        await WriteLog(logFile, $"ERROR deleting {file}: {ex.Message}");
                    }
                }
            }
        }
        private async Task WriteLog(string filePath, string message)
        {
            await File.AppendAllTextAsync(
                filePath,
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} — {message}\n"
            );
        }
        public static string RemoveBacktick(string name)
        {
            return string.IsNullOrEmpty(name)
                   ? name
                   : name.Replace("`", "").Replace("'", "");
        }
        private string SanitizeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }
    }
}
