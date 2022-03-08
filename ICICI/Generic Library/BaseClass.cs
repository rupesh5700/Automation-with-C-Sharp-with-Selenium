using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ICICI.Generic_Library
{
    public class BaseClass
    {
        ExtentReports extent;
        ExtentTest test;
        public static IWebDriver driver;

        [OneTimeSetUp]
                public void Init()
                {
                    string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                    string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                    string projectPath = new Uri(actualPath).LocalPath;
                    Console.WriteLine("nhfhrifhrfhggh" + projectPath);
                    string reportPath = projectPath + "Reports\\ExtentScreenshot.html";
                    Console.WriteLine(reportPath);
                    extent = new ExtentReports();
                    var htmlReporter = new ExtentHtmlReporter(reportPath);
            
                    htmlReporter.Config.DocumentTitle = "Automation Testing Report";
                    htmlReporter.Config.ReportName = "Regression Testing";
                    htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("Application Under Test", "nop Commerce Demo");
                    extent.AddSystemInfo("Environment", "QA");
                    extent.AddSystemInfo("Machine", Environment.MachineName);
                    extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
                    Console.WriteLine("Start generating report");
                }

        [SetUp]
        public void CaptureScreenshot()
        {
            test = extent.CreateTest("CaptureScreenshot").Info("Test Startted");
            driver = new ChromeDriver();
            // driver.Navigate().GoToUrl("http://www.automationtesting.in");
            driver.Navigate().GoToUrl("https://www.google.co.in/");
            string title = driver.Title;
            Assert.AreEqual("Google", title);
            test.Log(Status.Pass, "Test Passed");
        }

        [TearDown]
                public void GetResult()
                {
                    var status = TestContext.CurrentContext.Result.Outcome.Status;
                    var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                    var errorMessage = TestContext.CurrentContext.Result.Message;

                    if (status == TestStatus.Failed)
                    {
                        string screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                       // Console.WriteLine(screenShotPath);
                        test.Log(Status.Fail, stackTrace + errorMessage);
                        test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
                    }
                    //extent.EndTest(test);
                }
        [OneTimeTearDown]
                public void Endreport()
                {
                    driver.Close();
                    extent.Flush();
                   // extent.Close();
                }



        
    }
}
