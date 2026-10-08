namespace MedicalRecordApi.Interface
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewToStringAsync(string viewName, object model);
    }
}
