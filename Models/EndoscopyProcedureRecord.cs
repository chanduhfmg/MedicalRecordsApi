using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalRecordApi.Models
{
    public class EndoscopyProcedureRecord
    {
        [Key]
        public int Id { get; set; }
        public string? AccNo { get; set; }

        // 🧾 PATIENT / PROCEDURE HEADER
        [Required(ErrorMessage = "Patient Name is required.")]
        [Display(Name = "Patient Name")]
        public string? PatientName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Procedure Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Procedure Date is required.")]
        public DateTime? ProcedureDate { get; set; }

        [Display(Name = "Time In")]
        [DataType(DataType.Time)]
        public TimeSpan? TimeIn { get; set; }

        [Display(Name = "Procedure Room Number")]
        [StringLength(50)]
        public string? ProcedureRoom { get; set; }

        [Display(Name = "Physician")]
        public string? ReferringPhysician { get; set; }

        [Display(Name = "Anesthesiologist")]
        public string? Anesthesiologist { get; set; }

        [Display(Name = "Procedure Assistant")]
        public string? Assistant { get; set; }

        [Display(Name = "NPO Since")]
        public string? NPOSince { get; set; }

        [Display(Name = "Prep Taken")]
        public string? PrepTaken { get; set; }


        // ⚕️ PRE-OP CHECKS
        [Display(Name = "Glasses Removed")]
        public string? GlassesRemoved { get; set; }

        [Display(Name = "Dentures Removed")]
        public string? DenturesRemoved { get; set; }

        [Display(Name = "Pregnancy Verified")]
        public string? PregnancyVerified { get; set; }

        [Display(Name = "Pre-op Diagnosis / Indication")]
        [DataType(DataType.MultilineText)]
        public string? PreOpDiagnosis { get; set; }


        // 🕒 TIME OUT COMPLETED
        [Display(Name = "Procedure Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan? ProcedureStart { get; set; }

        [Display(Name = "Procedure Stop Time")]
        [DataType(DataType.Time)]
        public TimeSpan? ProcedureStop { get; set; }

        [Display(Name = "Correct Patient (Name/DOB)")]
        public bool CorrectPatient { get; set; }

        [Display(Name = "Correct Procedure")]
        public bool CorrectProcedure { get; set; }

        [Display(Name = "Allergies Verified")]
        public bool AllergiesVerified { get; set; }

        [Display(Name = "Verified w/ Staff")]
        public bool VerifiedWithStaff { get; set; }


        // 🔬 PROCEDURE TYPES
        [Display(Name = "EGD")]
        public bool IsEGD { get; set; }

        [Display(Name = "Colonoscopy")]
        public bool IsColonoscopy { get; set; }

        [Display(Name = "Flex Sig")]
        public bool IsFlexSig { get; set; }

        [Display(Name = "With Banding")]
        public bool IsBanding { get; set; }


        // ⚙️ EQUIPMENT / CAUTERY SETTINGS
        [Display(Name = "Endoscope ID")]
        public string? EndoscopeId { get; set; }

        [Display(Name = "Cautery N/A")]
        public bool CauteryNA { get; set; }

        [Display(Name = "Cautery Cut")]
        public string? CauteryCut { get; set; }

        [Display(Name = "Cautery Co")]
        public string? CauteryCo { get; set; }

        [Display(Name = "Number of Specimens")]
        [Range(0, 50, ErrorMessage = "Please enter a valid specimen count.")]
        public int? SpecimenCount { get; set; }

        [Display(Name = "Procedure Notes")]
        [DataType(DataType.MultilineText)]
        public string? ProcedureNotes { get; set; }


        // 💉 IV THERAPY
        [Display(Name = "IV None")]
        public bool IVNone { get; set; }

        [Display(Name = "IV Started")]
        public bool IVStarted { get; set; }

        [Display(Name = "IV Site")]
        public string? IVSite { get; set; }

        [Display(Name = "LiB")]
        public string? LiB { get; set; }


        // 🏥 NURSES & ANESTHESIA
        [Display(Name = "Nursing Notes")]
        [DataType(DataType.MultilineText)]
        public string? NursingNotes { get; set; }

        [Display(Name = "Anesthesia - TIVA")]
        public bool AnesthesiaTIVA { get; set; }

        [Display(Name = "Anesthesia - Conscious Sedation")]
        public bool AnesthesiaConsciousSedation { get; set; }

        [Display(Name = "Anesthesia - GA")]
        public bool AnesthesiaGA { get; set; }

        [Display(Name = "Anesthesia - None")]
        public bool AnesthesiaNone { get; set; }


        // 🩺 MONITORS
        [Display(Name = "Monitor EKG")]
        public bool MonitorEKG { get; set; }

        [Display(Name = "Monitor ETCO2")]
        public bool MonitorETCO2 { get; set; }

        [Display(Name = "Monitor NIBP")]
        public bool MonitorNIBP { get; set; }

        [Display(Name = "Monitor Pulse Oximeter")]
        public bool MonitorPulseOx { get; set; }


        // ❤️ VITAL SIGNS
        [Display(Name = "B/P")]
        [StringLength(20)]
        public string? BP { get; set; }

        [Display(Name = "Heart Rate")]
        [StringLength(20)]
        public string? HR { get; set; }

        [Display(Name = "Respiratory Rate")]
        [StringLength(20)]
        public string? RespRate { get; set; }

        [Display(Name = "O2 Saturation")]
        [StringLength(20)]
        public string? SpO2 { get; set; }

        [Display(Name = "Oxygen")]
        [StringLength(50)]
        public string? Oxygen { get; set; }


        // 🚑 DISCHARGE DETAILS
        [Display(Name = "Discharge to PACU Time")]
        [DataType(DataType.Time)]
        public TimeSpan? PACUTransferTime { get; set; }

        [Display(Name = "Photos on File")]
        public bool PhotosOnFile { get; set; }

        [Display(Name = "Created At")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Default value

        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? PdfFilePath { get; set; }

        public bool BotJobDone { get; set; }

        public bool? PostOp { get; set; }

        public string? facility { get; set; }

    }
}
