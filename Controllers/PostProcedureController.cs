using Humanizer;
using MedicalRecordApi.Data;
using MedicalRecordApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalRecordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostProcedureController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public PostProcedureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PostProcedure>
        [HttpGet("post-op/{id:int}")]
        public async Task<ActionResult<EndoscopyPostProcedureRecordDto>> GetPostOp(int id)
        {
            var postOp = await _context.EndoscopyPostProcedureRecords
                .Include(p => p.MonitoringRows)
                .Include(p => p.NursingMedications)
                .Include(p => p.Aldrete)
                .FirstOrDefaultAsync(p => p.EndoscopyProcedureRecordId == id);

            if (postOp == null)
                return NotFound();

            return Ok(postOp);
        }

        // GET api/<PostProcedure>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExists(int id)
        {
            var exists = await _context.EndoscopyPostProcedureRecords
                                       .AnyAsync(e => e.EndoscopyProcedureRecordId == id);

            return Ok(exists);
        }

        // POST api/<PostProcedure>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EndoscopyPostProcedureRecordDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request.");

            var existing = await _context.EndoscopyPostProcedureRecords
    .Include(p => p.MonitoringRows)
    .Include(p => p.NursingMedications)
    .Include(p => p.Aldrete)
    .FirstOrDefaultAsync(p => p.EndoscopyProcedureRecordId == dto.EndoscopyProcedureRecordId);

            if (existing != null)
            {
                // ==================================
                // ✔ UPDATE EXISTING RECORD
                // ==================================

                existing.AccNo = dto.AccNo;
                existing.Patient = dto.Patient;
                existing.DateOfBirth = dto.DateOfBirth;
                existing.AdmissionDate = dto.AdmissionDate;
                existing.AdmissionTime = dto.AdmissionTime;
                existing.OperativeProcedure = dto.OperativeProcedure;
                existing.BP = dto.BP;
                existing.HeartRate = dto.HeartRate;
                existing.Respiration = dto.Respiration;
                existing.O2Sat = dto.O2Sat;
                existing.On = dto.On;
                existing.IVAmtOnAdmission = dto.IVAmtOnAdmission;
                existing.TotalInfused = dto.TotalInfused;
                existing.TimeSiteDC = dto.TimeSiteDC;
                existing.AbdomenSoft = dto.AbdomenSoft;
                existing.PassingFlatus = dto.PassingFlatus;
                existing.NauseaVomiting = dto.NauseaVomiting;
                existing.OralFluidsTolerated = dto.OralFluidsTolerated;
                existing.Notes = dto.Notes;
                existing.PainLevel = dto.PainLevel;
                existing.Location = dto.Location;
                existing.Description = dto.Description;
                existing.Action = dto.Action;
                existing.Reassessment = dto.Reassessment;
                existing.NursingNotes = dto.NursingNotes;
                existing.AdditionalOrders = dto.AdditionalOrders;
                existing.PhysicianName = dto.PhysicianName;
                existing.PhysicianDate = dto.PhysicianDate;
                existing.DischargeCriteriaMet = dto.DischargeCriteriaMet;
                existing.StableVitalSigns = dto.StableVitalSigns;
                existing.ClearedByAnesthesiologist = dto.ClearedByAnesthesiologist;
                existing.InstructionsReviewed = dto.InstructionsReviewed;
                existing.InstructionsReviewedBy = dto.InstructionsReviewedBy;
                existing.PostOpInstructionsGiven = dto.PostOpInstructionsGiven;
                existing.PostOpInstructionsGivenBy = dto.PostOpInstructionsGivenBy;
                existing.PatientDischargeType = dto.PatientDischargeType;
                existing.PatientDischargeTime = dto.PatientDischargeTime;

                // MONITORING ROWS UPDATE
                _context.AssessmentMonitoringRows.RemoveRange(existing.MonitoringRows);
                existing.MonitoringRows = dto.MonitoringRows.Select(m => new AssessmentMonitoringRow
                {
                    EndoscopyPostProcedureRecordId = dto.EndoscopyProcedureRecordId,
                    Time = m.Time,
                    BP = m.BP,
                    Pulse = m.Pulse,
                    Resp = m.Resp,
                    O2 = m.O2,
                    O2Sat = m.O2Sat
                }).ToList();

                // NURSING MEDICATIONS UPDATE
                _context.NursingMedicationEntries.RemoveRange(existing.NursingMedications);
                existing.NursingMedications = dto.NursingMedications.Select(n => new NursingMedicationEntry
                {
                    EndoscopyPostProcedureRecordId = dto.EndoscopyProcedureRecordId,
                    Time = n.Time,
                    Medication = n.Medication,
                    Route = n.Route,
                    Nurse = n.Nurse,
                    Response = n.Response
                }).ToList();

                // ALDRETE UPDATE
                if (existing.Aldrete == null)
                    existing.Aldrete = new AldreteScore();

                existing.Aldrete.ActivityAd = dto.Aldrete.ActivityAd;
                existing.Aldrete.Activity10 = dto.Aldrete.Activity10;
                existing.Aldrete.Activity20 = dto.Aldrete.Activity20;
                existing.Aldrete.ActivityDC = dto.Aldrete.ActivityDC;
                existing.Aldrete.RespirationAd = dto.Aldrete.RespirationAd;
                existing.Aldrete.Respiration10 = dto.Aldrete.Respiration10;
                existing.Aldrete.Respiration20 = dto.Aldrete.Respiration20;
                existing.Aldrete.RespirationDC = dto.Aldrete.RespirationDC;
                existing.Aldrete.ConsciousnessAd = dto.Aldrete.ConsciousnessAd;
                existing.Aldrete.Consciousness10 = dto.Aldrete.Consciousness10;
                existing.Aldrete.Consciousness20 = dto.Aldrete.Consciousness20;
                existing.Aldrete.ConsciousnessDC = dto.Aldrete.ConsciousnessDC;
                existing.Aldrete.O2SatAd = dto.Aldrete.O2SatAd;
                existing.Aldrete.O2Sat10 = dto.Aldrete.O2Sat10;
                existing.Aldrete.O2Sat20 = dto.Aldrete.O2Sat20;
                existing.Aldrete.O2SatDC = dto.Aldrete.O2SatDC;
                existing.Aldrete.CirculationAd = dto.Aldrete.CirculationAd;
                existing.Aldrete.Circulation10 = dto.Aldrete.Circulation10;
                existing.Aldrete.Circulation20 = dto.Aldrete.Circulation20;
                existing.Aldrete.CirculationDC = dto.Aldrete.CirculationDC;

                await _context.SaveChangesAsync();

                return Ok("Updated successfully");
            }


            var entity = new EndoscopyPostProcedureRecord
            {
                AccNo = dto.AccNo,
                EndoscopyProcedureRecordId = dto.EndoscopyProcedureRecordId,
                Patient = dto.Patient,
                DateOfBirth = dto.DateOfBirth,
                AdmissionDate = dto.AdmissionDate,
                AdmissionTime = dto.AdmissionTime,
                OperativeProcedure = dto.OperativeProcedure,
                BP = dto.BP,
                HeartRate = dto.HeartRate,
                Respiration = dto.Respiration,
                O2Sat = dto.O2Sat,
                On = dto.On,
                IVAmtOnAdmission = dto.IVAmtOnAdmission,
                TotalInfused = dto.TotalInfused,
                TimeSiteDC = dto.TimeSiteDC,
                AbdomenSoft = dto.AbdomenSoft,
                PassingFlatus = dto.PassingFlatus,
                NauseaVomiting = dto.NauseaVomiting,
                OralFluidsTolerated = dto.OralFluidsTolerated,
                Notes = dto.Notes,
                PainLevel = dto.PainLevel,
                Location = dto.Location,
                Description = dto.Description,
                Action = dto.Action,
                Reassessment = dto.Reassessment,
                NursingNotes = dto.NursingNotes,
                AdditionalOrders = dto.AdditionalOrders,
                PhysicianName = dto.PhysicianName,
                PhysicianDate = dto.PhysicianDate,
                DischargeCriteriaMet = dto.DischargeCriteriaMet,
                StableVitalSigns = dto.StableVitalSigns,
                ClearedByAnesthesiologist = dto.ClearedByAnesthesiologist,
                InstructionsReviewed = dto.InstructionsReviewed,
                InstructionsReviewedBy = dto.InstructionsReviewedBy,
                PostOpInstructionsGiven = dto.PostOpInstructionsGiven,
                PostOpInstructionsGivenBy = dto.PostOpInstructionsGivenBy,
                PatientDischargeType = dto.PatientDischargeType,
                PatientDischargeTime = dto.PatientDischargeTime,
                MonitoringRows = dto.MonitoringRows.Select(m => new AssessmentMonitoringRow
                {
                    EndoscopyPostProcedureRecordId = dto.EndoscopyProcedureRecordId,
                    Time = m.Time,
                    BP = m.BP,
                    Pulse = m.Pulse,
                    Resp = m.Resp,
                    O2 = m.O2,
                    O2Sat = m.O2Sat
                }).ToList(),
                NursingMedications = dto.NursingMedications.Select(n => new NursingMedicationEntry
                {
                    EndoscopyPostProcedureRecordId = dto.EndoscopyProcedureRecordId,
                    Time = n.Time,
                    Medication = n.Medication,
                    Route = n.Route,
                    Nurse = n.Nurse,
                    Response = n.Response
                }).ToList(),
                Aldrete = new AldreteScore
                {
                    EndoscopyPostProcedureRecordId = dto.EndoscopyProcedureRecordId,
                    ActivityAd = dto.Aldrete.ActivityAd,
                    Activity10 = dto.Aldrete.Activity10,
                    Activity20 = dto.Aldrete.Activity20,
                    ActivityDC = dto.Aldrete.ActivityDC,
                    RespirationAd = dto.Aldrete.RespirationAd,
                    Respiration10 = dto.Aldrete.Respiration10,
                    Respiration20 = dto.Aldrete.Respiration20,
                    RespirationDC = dto.Aldrete.RespirationDC,
                    ConsciousnessAd = dto.Aldrete.ConsciousnessAd,
                    Consciousness10 = dto.Aldrete.Consciousness10,
                    Consciousness20 = dto.Aldrete.Consciousness20,
                    ConsciousnessDC = dto.Aldrete.ConsciousnessDC,
                    O2SatAd = dto.Aldrete.O2SatAd,
                    O2Sat10 = dto.Aldrete.O2Sat10,
                    O2Sat20 = dto.Aldrete.O2Sat20,
                    O2SatDC = dto.Aldrete.O2SatDC,
                    CirculationAd = dto.Aldrete.CirculationAd,
                    Circulation10 = dto.Aldrete.Circulation10,
                    Circulation20 = dto.Aldrete.Circulation20,
                    CirculationDC = dto.Aldrete.CirculationDC
                }
            };

            try
            {
                _context.EndoscopyPostProcedureRecords.Add(entity);

                
                await _context.SaveChangesAsync();

                var procedure = await _context.EndoscopyProcedureRecords
                                      .FirstOrDefaultAsync(p => p.Id == entity.EndoscopyProcedureRecordId);

                if (procedure != null)
                {
                    procedure.PostOp = true; 
                    _context.EndoscopyProcedureRecords.Update(procedure);
                    await _context.SaveChangesAsync();
                }

                return Ok(new { message = "Record saved successfully"});
            }
            catch (Exception ex)
            {
                // Log to console (for testing)
                Console.WriteLine("Exception message: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);

                // If inner exceptions exist
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    Console.WriteLine("Inner Stack Trace: " + ex.InnerException.StackTrace);
                }

                return StatusCode(500, new
                {
                    message = "Error saving record",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }

        // PUT api/<PostProcedure>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostProcedure>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
