using MedicalRecordApi.Controllers;
using MedicalRecordApi.Data;
using MedicalRecordApi.Interface;
using MedicalRecordApi.Service;
using Microsoft.EntityFrameworkCore;
using MedicalRecordApi.Helpers;
using DinkToPdf;
using DinkToPdf.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHostedService<NightlyPdfGenerator>();


builder.Services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();

var context = new CustomAssemblyLoadContext();
var dllPath = Path.Combine(builder.Environment.ContentRootPath, "DinkToPdf", "64bit", "libwkhtmltox.dll");
context.LoadUnmanagedLibrary(dllPath);

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
