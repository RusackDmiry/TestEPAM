using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static IWebDriver webDriverChrome;
        [AssemblyInitialize]
        public static void One(TestContext testContext)
        {
            try
            {
                webDriverChrome = new ChromeDriver(@"D:\УЧЁБА\4 курс\7 cеместр\ЕПАМ\chrome");
            }
            catch (Exception exception)
            {
                exception.StackTrace.ToString();
            }

        }


        [TestMethod]
        public void TestMethod1()
        {
            webDriverChrome.Navigate().GoToUrl("http://www.github.com/");
            webDriverChrome.FindElement(By.XPath("//a[text() = 'Sign in']")).Click();
            
            webDriverChrome.FindElement(By.XPath("//input[@id='login_field']")).SendKeys(" DimaRusak");
            webDriverChrome.FindElement(By.XPath("//input[@id='password']")).SendKeys("12345678");

            System.Threading.Thread.Sleep(10000);
        }
        [TestCleanup]
        public void TearDown()
        {
            webDriverChrome.Quit();
        }
    }
}
