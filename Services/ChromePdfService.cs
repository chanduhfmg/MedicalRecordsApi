using Microsoft.Playwright;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace MedicalRecord.Service
{
    public class ChromePdfService
    {
        public async Task<byte[]> GeneratePdfAsync(string html)
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            await page.SetContentAsync(html);

            return await page.PdfAsync(new PagePdfOptions
            {
                Format = "A4"
            });
        }
        //public async Task<byte[]> GeneratePdfAsync(string htmlContent)
        //{

        //    var browserFetcher = new BrowserFetcher();
        //    await browserFetcher.DownloadAsync();

        //    var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        //    {
        //        Headless = true,
        //        Args = new[]
        //    {
        //        "--no-sandbox",
        //        "--disable-setuid-sandbox",
        //        "--disable-dev-shm-usage",
        //        "--disable-gpu"
        //    }
        //    });

        //    var page = await browser.NewPageAsync();

        //    // 💥 FORCE DESKTOP MODE (IMPORTANT)
        //    await page.SetViewportAsync(new ViewPortOptions
        //    {
        //        Width = 2120,
        //        Height = 1080,
        //        DeviceScaleFactor = 1,
        //        IsMobile = false,
        //        HasTouch = false
        //    });

        //    // 💥 FORCE SCREEN CSS (Bootstrap desktop)
        //    await page.EmulateMediaTypeAsync(PuppeteerSharp.Media.MediaType.Screen);

        //    // Load HTML content
        //    await page.SetContentAsync(htmlContent, new NavigationOptions
        //    {
        //        WaitUntil = new[]
        //        {
        //        WaitUntilNavigation.Load,
        //        WaitUntilNavigation.Networkidle0
        //    }
        //    });

        //    await Task.Delay(300);

        //    // Generate PDF
        //    var pdfBytes = await page.PdfDataAsync(new PdfOptions
        //    {
        //        PrintBackground = true,
        //        Format = PuppeteerSharp.Media.PaperFormat.A4,
        //        MarginOptions = new PuppeteerSharp.Media.MarginOptions
        //        {
        //            Top = "10mm",
        //            Bottom = "10mm",
        //            Left = "10mm",
        //            Right = "10mm"
        //        }
        //    });

        //    // Close browser LAST
        //    await browser.CloseAsync();

        //    return pdfBytes;
        //}
    }
}
