using System.ComponentModel.DataAnnotations;

namespace MedicalRecordApi.Models
{
    public class EndoscopyPostProcedureRecord
    {
        [Key]
        public int Id { get; set; }

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

        public int? PainLevel { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? Action { get; set; }
        public string? Reassessment { get; set; }

        public AldreteScore Aldrete { get; set; }
        public List<AssessmentMonitoringRow> MonitoringRows { get; set; }
        public List<NursingMedicationEntry> NursingMedications { get; set; }

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

}
