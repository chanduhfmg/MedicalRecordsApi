using MedicalRecordApi.Data;
using MedicalRecordApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace MedicalRecordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public ValuesController(ApplicationDbContext db) { _db = db; }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<EndoscopyProcedureRecord>> Get([FromQuery] DateTime date , string? facility)
        {
            var query = _db.EndoscopyProcedureRecords
           .Where(r => r.CreatedAt.Date == date.Date && r.PdfFilePath == null);

                if (!string.IsNullOrWhiteSpace(facility))
                {
                    query = query.Where(r => r.facility == facility);
                }

                var list = await query
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();

                return list;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EndoscopyProcedureRecord>> Get(int id)
        {
            var rec = await _db.EndoscopyProcedureRecords.FirstOrDefaultAsync(e => e.Id == id);


            if (rec == null)
                return NotFound();

            return Ok(rec);
            
        }

        [HttpGet("get-procedure/{id:int}")]
        public async Task<ActionResult<BothEndocopyForm>> GetBothForms(int id)
        {
        
            var preOp = await _db.EndoscopyProcedureRecords
                                 .FirstOrDefaultAsync(e => e.Id == id);

            
            var postOp = await _db.EndoscopyPostProcedureRecords
                                   .Include(r => r.Aldrete)           
                                   .Include(r => r.MonitoringRows)
                                   .Include(r => r.NursingMedications)
                                   .FirstOrDefaultAsync(r => r.Id == id);

            if (preOp == null && postOp == null)
                return NotFound();

            var both = new BothEndocopyForm
            {
                PreOp = preOp,
                PostOp = postOp
            };

            return Ok(both);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EndoscopyProcedureRecord model)
        {
            try
            {
                EndoscopyProcedureRecord record;

                if (model.Id > 0)
                {
                    // LOAD EXISTING RECORD
                    record = await _db.EndoscopyProcedureRecords
                        .FirstOrDefaultAsync(x => x.Id == model.Id);

                    if (record == null)
                        return NotFound(new { message = "Record not found." });

                    // ---------- UPDATE ALL FIELDS MANUALLY ----------
                    record.AccNo = model.AccNo;

                    // PATIENT DETAILS
                    record.PatientName = model.PatientName;
                    record.DOB = model.DOB;
                    record.ProcedureDate = model.ProcedureDate;
                    record.TimeIn = model.TimeIn;
                    record.ProcedureRoom = model.ProcedureRoom;
                    record.ReferringPhysician = model.ReferringPhysician;
                    record.Anesthesiologist = model.Anesthesiologist;
                    record.Assistant = model.Assistant;
                    record.NPOSince = model.NPOSince;
                    record.PrepTaken = model.PrepTaken;

                    // PRE-OP
                    record.GlassesRemoved = model.GlassesRemoved;
                    record.DenturesRemoved = model.DenturesRemoved;
                    record.PregnancyVerified = model.PregnancyVerified;
                    record.PreOpDiagnosis = model.PreOpDiagnosis;

                    // TIME OUT
                    record.ProcedureStart = model.ProcedureStart;
                    record.ProcedureStop = model.ProcedureStop;
                    record.CorrectPatient = model.CorrectPatient;
                    record.CorrectProcedure = model.CorrectProcedure;
                    record.AllergiesVerified = model.AllergiesVerified;
                    record.VerifiedWithStaff = model.VerifiedWithStaff;

                    // PROCEDURE TYPES
                    record.IsEGD = model.IsEGD;
                    record.IsColonoscopy = model.IsColonoscopy;
                    record.IsFlexSig = model.IsFlexSig;
                    record.IsBanding = model.IsBanding;

                    // EQUIPMENT
                    record.EndoscopeId = model.EndoscopeId;
                    record.CauteryNA = model.CauteryNA;
                    record.CauteryCut = model.CauteryCut;
                    record.CauteryCo = model.CauteryCo;
                    record.SpecimenCount = model.SpecimenCount;
                    record.ProcedureNotes = model.ProcedureNotes;

                    // IV THERAPY
                    record.IVNone = model.IVNone;
                    record.IVStarted = model.IVStarted;
                    record.IVSite = model.IVSite;
                    record.LiB = model.LiB;

                    // NURSING / ANESTHESIA
                    record.NursingNotes = model.NursingNotes;
                    record.AnesthesiaTIVA = model.AnesthesiaTIVA;
                    record.AnesthesiaConsciousSedation = model.AnesthesiaConsciousSedation;
                    record.AnesthesiaGA = model.AnesthesiaGA;
                    record.AnesthesiaNone = model.AnesthesiaNone;

                    // MONITORS
                    record.MonitorEKG = model.MonitorEKG;
                    record.MonitorETCO2 = model.MonitorETCO2;
                    record.MonitorNIBP = model.MonitorNIBP;
                    record.MonitorPulseOx = model.MonitorPulseOx;

                    // VITALS
                    record.BP = model.BP;
                    record.HR = model.HR;
                    record.RespRate = model.RespRate;
                    record.SpO2 = model.SpO2;
                    record.Oxygen = model.Oxygen;

                    // DISCHARGE
                    record.PACUTransferTime = model.PACUTransferTime;
                    record.PhotosOnFile = model.PhotosOnFile;

                    // MISC
                    record.PdfFilePath = model.PdfFilePath;
                    record.BotJobDone = model.BotJobDone;
                    record.PostOp = model.PostOp;

                    // ❌ DO NOT MODIFY record.CreatedAt (keep original)
                }
                else
                {
                    // ----- CREATE NEW RECORD -----
                    model.CreatedAt = DateTime.Now;
                    record = model;
                    _db.EndoscopyProcedureRecords.Add(record);
                }

                await _db.SaveChangesAsync();

                return Ok(new { Message = "Saved successfully", Id = record.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EndoscopyProcedureRecord value)
        {
            if (id != value.Id)
                return BadRequest(new { message = "ID mismatch." });

            var existing = await _db.EndoscopyProcedureRecords.FindAsync(id);
            if (existing == null)
                return NotFound(new { message = "Record not found." });

            // Update all fields
            _db.Entry(existing).CurrentValues.SetValues(value);

            try
            {
                await _db.SaveChangesAsync();
                return Ok(new { message = "Record updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating record.", error = ex.Message });
            }
        }


        // pdf 


        [HttpGet("get-records-of/{date}")]
        public async Task<ActionResult<List<BothEndocopyForm>>> GetRecordsOf(string date)
        {
            if (!DateTime.TryParse(date, out var parsedDate))
                return BadRequest("Invalid date format");

            var preOpRecords = await _db.EndoscopyProcedureRecords
                .Where(x => x.CreatedAt.Date == parsedDate.Date)
                .ToListAsync();

            if (preOpRecords == null || preOpRecords.Count == 0)
                return Ok(new List<BothEndocopyForm>());

            var resultList = new List<BothEndocopyForm>();

            foreach (var pre in preOpRecords)
            {
                var postOp = await _db.EndoscopyPostProcedureRecords
                    .Include(r => r.Aldrete)
                    .Include(r => r.MonitoringRows)
                    .Include(r => r.NursingMedications)
                    .FirstOrDefaultAsync(r => r.EndoscopyProcedureRecordId == pre.Id);

                var combined = new BothEndocopyForm
                {
                    PreOp = pre,
                    PostOp = postOp
                };

                resultList.Add(combined);
            }
            return Ok(resultList);
        }

        [HttpGet("test-playwright")]
        public async Task<IActionResult> TestPlaywright()
        {
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            string logPath = Path.Combine(logDirectory, "test-playwright.log");

            // Ensure Logs folder exists
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            try
            {
                using var pw = await Playwright.CreateAsync();
                 
                var chromiumPath = pw.Chromium.ExecutablePath;

                var browser = await pw.Chromium.LaunchAsync(new()
                {
                    Headless = true
                });

                await browser.CloseAsync();

                string successMsg = $"[{DateTime.Now}] ✔ Playwright launched successfully! Path: {chromiumPath}\n";
                await System.IO.File.AppendAllTextAsync(logPath, successMsg);

                return Ok("✔ Playwright launched successfully!");
            }
            catch (Exception ex)
            {
                string errorMsg = $"[{DateTime.Now}] ❌ Playwright failed: {ex.Message}\n{ex.StackTrace}\n\n";
                await System.IO.File.AppendAllTextAsync(logPath, errorMsg);

                return StatusCode(500, errorMsg);
            }
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
