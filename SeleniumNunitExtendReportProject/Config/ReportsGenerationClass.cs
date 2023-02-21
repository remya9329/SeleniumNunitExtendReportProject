using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using AventStack.ExtentReports.Model;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace SeleniumNUnitExtentReport.Config
{
   
    
    [SetUpFixture]
    public abstract class ReportsGenerationClass
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        public IWebDriver _driver;
        string statusText;
        Status logstatus;


        [OneTimeSetUp]
        protected void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
           // ChromeDriverService service = ChromeDriverService.CreateDefaultService("webdriver.chrome.driver", @"C:\\Program Files\\Google\\Chrome Beta\\Application\\chromedriver.exe");
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _driver.Manage().Window.Maximize();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            statusText = status.ToString();
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
: string.Format("{ 0}", TestContext.CurrentContext.Result.StackTrace);

            //if (status.ToString() != "" || status.ToString() != null)
            //{
            //    if (status.ToString() == "Failed" || status.ToString() == "FAILED" || status.ToString() == "failed" || status.ToString() == "Fail")
            //    {
            //        logstatus = Status.Fail;
            //        DateTime time = DateTime.Now;
            //        String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            //        String screenShotPath = Capture(_driver, fileName);
            //        _test.Log(Status.Fail, "Fail");
            //        _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));

            //    }
            //    else if (status.ToString() == "Inconclusive" || status.ToString() == "INCONCLUSIVE" || status.ToString() == "inconclusive")
            //    {
            //        logstatus = Status.Warning;
            //    }
            //    else if (status.ToString() == "Skipped" || status.ToString() == "SKIPPED" || status.ToString() == "skipped" || status.ToString() == "Skip")
            //    {
            //        logstatus = Status.Skip;
            //    }
            //    else if (status.ToString() == "Passed" || status.ToString() == "PASSED" || status.ToString() == "passed" || status.ToString() == "pass")
            //    {
            //        logstatus = Status.Pass;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            switch (status.ToLower())
            {

                case "Failed":
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(_driver, fileName);
                    _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case "inconclusive":
                    logstatus = Status.Warning;
                    break;
                case "skipped":
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with ddfd " + status + logstatus);
            _extent.Flush();
            _driver.Quit();
        }
        public IWebDriver GetDriver()
        {
            return _driver;
        }

        //public string GetStatusText()
        //{
        //    return;

        //}
        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" +screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}