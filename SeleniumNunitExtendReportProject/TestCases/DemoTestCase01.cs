using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumNUnitExtentReport.Config;
using SeleniumNUnitExtentReport.PageMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitExtentReport.TestCases
{
    
    [TestFixture]
    public class DemoTestCase01 : ReportsGenerationClass
    {
        DemoPage demoPage;
        
        [Category("Demo")]

        [Test, Order(1)]
        public void Executetest_One()
        {
            demoPage = new DemoPage(GetDriver());
            demoPage.goToPage();
            demoPage.Executetest_One();
            // Console.WriteLine("test status", GetStatusText());
            //Assert.IsTrue(loginPage.verifyDashboard());
            demoPage.closeBrowser();
        }

        [Test, Order(2)]
        public void Executetest_Two()
        {
            demoPage = new DemoPage(GetDriver());
            demoPage.goToPage();
            demoPage.Executetest_Two();
            //Console.WriteLine("test status", GetStatusText());
            demoPage.closeBrowser();
        }

        [Test, Order(3)]
        public void Executetest_Three()
        {
            demoPage = new DemoPage(GetDriver());
            demoPage.goToPage();
            demoPage.Executetest_Three();
            //Console.WriteLine("test status", GetStatusText());
            demoPage.closeBrowser();
        }

        [Test, Order(4)]
        [Ignore("Not Applicable TC")]
        public void Executetest_Four()
        {
            demoPage = new DemoPage(GetDriver());
            demoPage.goToPage();
            demoPage.Executetest_Four();
            //Console.WriteLine("test status", GetStatusText());
            demoPage.closeBrowser();
        }

        [Test, Order(5)]
        [Repeat(2)]
        public void Executetest_Five()
        {
            demoPage = new DemoPage(GetDriver());
            demoPage.goToPage();
            demoPage.Executetest_Five();
            // Console.WriteLine("test status", GetStatusText());
            demoPage.closeBrowser();
        }

        [Test, Order(6)]
        [Repeat(1)]
        public void Executetest_Six()
        {
            demoPage = new DemoPage(GetDriver());
            demoPage.goToPage();
            demoPage.Executetest_six();
            //  Console.WriteLine("test status", GetStatusText());
            demoPage.closeBrowser();
        }


    }
}
