using System.ComponentModel.DataAnnotations;

namespace MedicalRecordApi.Models
{
    public class AldreteScore
    {
        [Key]
        public int Id { get; set; }
        public int? ActivityAd { get; set; }
        public int? Activity10 { get; set; }
        public int? Activity20 { get; set; }
        public int? ActivityDC { get; set; }

        // Respiration
        public int? RespirationAd { get; set; }
        public int? Respiration10 { get; set; }
        public int? Respiration20 { get; set; }
        public int? RespirationDC { get; set; }

        // Consciousness
        public int? ConsciousnessAd { get; set; }
        public int? Consciousness10 { get; set; }
        public int? Consciousness20 { get; set; }
        public int? ConsciousnessDC { get; set; }

        // Oxygen Saturation
        public int? O2SatAd { get; set; }
        public int? O2Sat10 { get; set; }
        public int? O2Sat20 { get; set; }
        public int? O2SatDC { get; set; }

        // Circulation
        public int? CirculationAd { get; set; }
        public int? Circulation10 { get; set; }
        public int? Circulation20 { get; set; }
        public int? CirculationDC { get; set; }


        public int EndoscopyPostProcedureRecordId { get; set; }
    }
}
