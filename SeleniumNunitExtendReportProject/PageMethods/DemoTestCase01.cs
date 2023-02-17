using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExtentReport.PageMethods
{
    class DemoPage
    {
        private IWebDriver driver;
        
        public DemoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://google.com/");
        }

        public void Executetest_One()
        {
            IWebElement ELE = driver.FindElement(By.Name("q"));
            ELE.Clear();
            ELE.SendKeys("chatGPT");
            ELE.SendKeys(Keys.Enter);
            Console.WriteLine("Tescase 1 Passed. The page title is --  > " + driver.Title.ToString());
            Assert.AreEqual("chatGPT - Google Search", driver.Title.ToString());
            Console.WriteLine("Page Title is correct");
        }
       
        public void Executetest_Two()
        {
            IWebElement ELE = driver.FindElement(By.Name("q"));
            ELE.Clear();
            ELE.SendKeys("W3Schools");
            ELE.SendKeys(Keys.Enter);
            Console.WriteLine("Tescase 2 Passed. The page title is --  > " + driver.Title.ToString());
            Assert.AreEqual("W3Schools - Google Search", driver.Title.ToString());
            Console.WriteLine("Page Title is correct");
        }

        public void Executetest_Three()
        {
            IWebElement ELE = driver.FindElement(By.Name("q"));
            ELE.Clear();
            ELE.SendKeys("SBI Bank");
            ELE.SendKeys(Keys.Enter);
            string expectedTitle = "SBI Bank - Google Search";
            Console.WriteLine("Tescase 3 Passed. The page title is --  > " + driver.Title.ToString());
            Assert.AreEqual(expectedTitle, driver.Title.ToString());
            Console.WriteLine("Page Title is correct");
        }

        public void Executetest_Four()
        {
            IWebElement ELE = driver.FindElement(By.Name("q"));
            ELE.Clear();
            ELE.SendKeys("Bank of India");
            ELE.SendKeys(Keys.Enter);
            string expectedTitle = "Bank of India - Google Searc";
            Console.WriteLine("Tescase 4 Passed. The page title is --  > " + driver.Title.ToString());
            Assert.AreEqual(expectedTitle, driver.Title.ToString());
            Console.WriteLine("Page Title is correct");
            Assert.AreEqual(expectedTitle, driver.Title.ToString());
        }

        public void Executetest_Five()
        {
            IWebElement ELE = driver.FindElement(By.Name("q"));
            ELE.Clear();
            ELE.SendKeys("IIM Ahmedabad");
            ELE.SendKeys(Keys.Enter);
            string expectedTitle = "IIM Ahmedabad - Google Search";
            Console.WriteLine("Tescase 5 Passed. The page title is --  > " + driver.Title.ToString());
            Assert.AreEqual(expectedTitle, driver.Title.ToString());
            Console.WriteLine("Page Title is correct");
        }
        
        public void Executetest_six()
        {
            {
                IWebElement ELE = driver.FindElement(By.Name("q"));
                ELE.SendKeys("geeksforgeeks");
                ELE.SendKeys(Keys.Enter);
                try
                {
                    Assert.AreEqual("geeksforgeeks - Google", driver.Title.ToString());
                }
                catch (AssertionException)
                {
                    Assert.AreEqual("geeksforgeeks - Google Search", driver.Title.ToString());
                }
                Console.WriteLine("Tescase 6 Passed for Executing the webpage GeeksForGeeks");
            }
        }
       
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}