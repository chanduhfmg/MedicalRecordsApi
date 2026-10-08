namespace MedicalRecordApi.Models
{
    public class BothEndocopyForm
    {
        public EndoscopyPostProcedureRecord PostOp { get; set; } = new EndoscopyPostProcedureRecord();
        public EndoscopyProcedureRecord PreOp { get; set; } = new EndoscopyProcedureRecord();
    }
}
