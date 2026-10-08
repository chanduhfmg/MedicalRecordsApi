using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MedicalRecordApi.Helpers
{
    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(
            this Controller controller,
            string viewName,
            TModel model,
            bool partial = false)
        {
            controller.ViewData.Model = model;

            using var writer = new StringWriter();
            var serviceProvider = controller.HttpContext.RequestServices;
            var engine = (ICompositeViewEngine)serviceProvider.GetService(typeof(ICompositeViewEngine));
            var viewResult = engine.FindView(controller.ControllerContext, viewName, !partial);

            if (viewResult.Success == false)
                throw new FileNotFoundException($"View '{viewName}' not found.");

            var viewContext = new ViewContext(
                controller.ControllerContext,
                viewResult.View,
                controller.ViewData,
                controller.TempData,
                writer,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return writer.GetStringBuilder().ToString();
        }
    }
}
