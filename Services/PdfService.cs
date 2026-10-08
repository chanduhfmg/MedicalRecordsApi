using DinkToPdf;
using DinkToPdf.Contracts;

namespace MedicalRecordApi.Service
{
    public class PdfService
    {
        private readonly IConverter _converter;
        private readonly IWebHostEnvironment _env;

        public PdfService(IConverter converter, IWebHostEnvironment env)
        {
            _converter = converter;
            _env = env;
        }

        public byte[] GeneratePdf(string htmlContent)
        {
            var cssPath = Path.Combine(_env.WebRootPath, "wwwroot/css/bootstrap.min.css");

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                DPI = 300,
                Margins = new MarginSettings
                {
                    Top = 10,
                    Bottom = 10,
                    Left = 10,
                    Right = 10
                },
                 
            };

            var webSettings = new WebSettings
            {
                DefaultEncoding = "utf-8",
                LoadImages = true,
                EnableJavascript = true,

                UserStyleSheet = cssPath
            };

            var loadSettings = new LoadSettings
            {
                // Allows wkhtmltopdf to access local system files
                BlockLocalFileAccess = false
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = webSettings,
                LoadSettings = loadSettings,

                // Simple header
                HeaderSettings = new HeaderSettings
                {
                    FontSize = 9,
                    Right = "Page [page] of [toPage]"
                }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _converter.Convert(pdf);
        }


    }
}
