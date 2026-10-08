using System.ComponentModel.DataAnnotations;

namespace MedicalRecordApi.Models
{
    public class AssessmentMonitoringRow
    {
        [Key]
        public int Id { get; set; }

        public string? Time { get; set; }
        public string? BP { get; set; }
        public string? Pulse { get; set; }
        public string? Resp { get; set; }
        public string? O2 { get; set; }
        public string? O2Sat { get; set; }

        // Foreign key to parent record
        public int EndoscopyPostProcedureRecordId { get; set; }
    }
}
