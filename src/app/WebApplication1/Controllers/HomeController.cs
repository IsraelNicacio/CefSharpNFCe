using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using PuppeteerSharp;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static IWebDriver driver = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Link util para envio de comando no campo
            //https://scrapax.com/
            //https://webscraping.pro/example-of-scraping-with-selenium-webdriver-in-csharp/
            //https://scrapax.com/selenium-web-scraper-tutorial/
            //https://www.youtube.com/watch?v=gRoMR3NcpPQ&ab_channel=Scrapax
            //https://www.youtube.com/watch?v=6m7pStpscIE&ab_channel=Scrapax
            //https://www.youtube.com/watch?v=P7KigYDRhPg&ab_channel=Scrapax
            //https://www.youtube.com/watch?v=SjWT6MIyrrA&ab_channel=Scrapax
            //https://www.youtube.com/watch?v=VYKjUf72e4c&ab_channel=Scrapax

            //Esse e muito bom
            //https://www.scrapingbee.com/blog/web-scraping-csharp/


            /*
                var userNameField = driver.FindElementById("usr");
                var userPasswordField = driver.FindElementById("pwd");
                var loginButton = driver.FindElementByXPath("//input[@value='Login']");

                // Type user name and password
                userNameField.SendKeys("admin");
                userPasswordField.SendKeys("12345");
            */

            ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService(string.Concat(Directory.GetCurrentDirectory(), @"\wwwroot\Resources"));
            chromeService.HideCommandPromptWindow = true;
            chromeService.SuppressInitialDiagnosticInformation = true;

            OpenQA.Selenium.Chrome.ChromeOptions chromeOptions = new OpenQA.Selenium.Chrome.ChromeOptions();
            chromeOptions.AddArguments(string.Concat("--app=", @"http://nfce.fazenda.mg.gov.br/portalnfce/sistema/consultaarg.xhtml"));

            driver = new OpenQA.Selenium.Chrome.ChromeDriver(chromeService, chromeOptions);

            if (driver == null)
                    throw new Exception("WebDriver do Selenium não definido nas configurações");

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            string fullUrl = "https://en.wikipedia.org/wiki/List_of_programmers";

            List<string> programmerLinks = new List<string>();

            var options = new LaunchOptions()
            {
                Headless = true,
                ExecutablePath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
            };
            var browser = await Puppeteer.LaunchAsync(options, null, Product.Chrome);
            var page = await browser.NewPageAsync();
            await page.GoToAsync(fullUrl);
            var links = @"Array.from(document.querySelectorAll('a')).map(a => a.href);";
            var urls = await page.EvaluateExpressionAsync<string[]>(links);


            foreach (string url in urls)
            {
                programmerLinks.Add(url);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
