using System.ComponentModel.DataAnnotations;

namespace MedicalRecordApi.Models
{
    public class NursingMedicationEntry
    {
        [Key]
        public int Id { get; set; }

        public string? Time { get; set; }
        public string? Medication { get; set; }
        public string? Route { get; set; }
        public string? Nurse { get; set; }
        public string? Response { get; set; }

        public int EndoscopyPostProcedureRecordId { get; set; }
    }
}
