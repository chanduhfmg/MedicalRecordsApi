using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalRecordApi.Models
{
    public class EndoscopyPostProcedureRecordDto
    {
        [Key]
        public int Id { get; set; }

        // Link to main EndoscopyProcedureRecord (Foreign key)
        public int EndoscopyProcedureRecordId { get; set; }
        
        public string? AccNo { get; set; }
        public string Patient { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public TimeSpan? AdmissionTime { get; set; }
        public string? OperativeProcedure { get; set; }
        public string? BP { get; set; }
        public int? HeartRate { get; set; }
        public int? Respiration { get; set; }
        public int? O2Sat { get; set; }
        public string? On { get; set; }

        public int? IVAmtOnAdmission { get; set; }
        public int? TotalInfused { get; set; }
        public string? TimeSiteDC { get; set; }

        public bool? AbdomenSoft { get; set; }
        public bool? PassingFlatus { get; set; }
        public bool? NauseaVomiting { get; set; }
        public bool? OralFluidsTolerated { get; set; }
        public string? Notes { get; set; }

        public int PainLevel { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? Action { get; set; }
        public string? Reassessment { get; set; }

        public AldreteScoreDto Aldrete { get; set; } = new();
        public List<AssessmentMonitoringRowDto> MonitoringRows { get; set; } = new();
        public List<NursingMedicationEntryDto> NursingMedications { get; set; } = new();

        public string? NursingNotes { get; set; }
        public string? AdditionalOrders { get; set; }

        public string? PhysicianName { get; set; }
        public DateTime? PhysicianDate { get; set; }

        public bool? DischargeCriteriaMet { get; set; }
        public bool? StableVitalSigns { get; set; }
        public bool? ClearedByAnesthesiologist { get; set; }

        public bool? InstructionsReviewed { get; set; }
        public string? InstructionsReviewedBy { get; set; }

        public bool? PostOpInstructionsGiven { get; set; }
        public string? PostOpInstructionsGivenBy { get; set; }

        public string? PatientDischargeType { get; set; }
        public string? PatientDischargeTime { get; set; }
    }

    public class AldreteScoreDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(EndoscopyPostProcedureRecord))]
        public int EndoscopyPostProcedureRecordId { get; set; }

        public EndoscopyPostProcedureRecordDto? EndoscopyPostProcedureRecord { get; set; }


        public int? ActivityAd { get; set; }
        public int? Activity10 { get; set; }
        public int? Activity20 { get; set; }
        public int? ActivityDC { get; set; }
        public int? RespirationAd { get; set; }
        public int? Respiration10 { get; set; }
        public int? Respiration20 { get; set; }
        public int? RespirationDC { get; set; }
        public int? ConsciousnessAd { get; set; }
        public int? Consciousness10 { get; set; }
        public int? Consciousness20 { get; set; }
        public int? ConsciousnessDC { get; set; }
        public int? O2SatAd { get; set; }
        public int? O2Sat10 { get; set; }
        public int? O2Sat20 { get; set; }
        public int? O2SatDC { get; set; }
        public int? CirculationAd { get; set; }
        public int? Circulation10 { get; set; }
        public int? Circulation20 { get; set; }
        public int? CirculationDC { get; set; }
    }

    public class AssessmentMonitoringRowDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(EndoscopyPostProcedureRecord))]
        public int EndoscopyPostProcedureRecordId { get; set; }

        public EndoscopyPostProcedureRecordDto? EndoscopyPostProcedureRecord { get; set; }
        public string? Time { get; set; }
        public string? BP { get; set; }
        public string? Pulse { get; set; }
        public string? Resp { get; set; }
        public string? O2 { get; set; }
        public string? O2Sat { get; set; }
    }

    public class NursingMedicationEntryDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(EndoscopyPostProcedureRecord))]
        public int EndoscopyPostProcedureRecordId { get; set; }

        public EndoscopyPostProcedureRecordDto? EndoscopyPostProcedureRecord { get; set; }
        public string? Time { get; set; }
        public string? Medication { get; set; }
        public string? Route { get; set; }
        public string? Nurse { get; set; }
        public string? Response { get; set; }
    }
}
