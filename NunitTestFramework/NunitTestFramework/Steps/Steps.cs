using OpenQA.Selenium;
using System;
using System.Text;


namespace NunitTestFramework.Steps
{
    public class Steps
    {
        public void OpenMainPage()
        {
            mainPage.OpenPage();
        }
        IWebDriver driver;
        Pages.MainPage mainPage;
        
        Pages.ConfirmTripSummaryPage confirmTripSummaryPage;
        Pages.PassengerInfoPages passengerInfoPages;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void InitMainPage()
        {
            mainPage = new Pages.MainPage(driver);
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void InputStation (string from, string to)
        {
            mainPage.InputStation(from, to);
        }

        public void ClickSerch()
        {
            mainPage.SerchClick();
        }

        public void AddAdults(int count)
        {
            mainPage.ClickTravaler();
            mainPage.InputAdults(count);
        }

        public bool ErrorNameTo(string messeges)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return mainPage.GetErrorNameTo(messeges);
        }

        public bool ErrorConfirm(string messeges)
        {
            return mainPage.GetErrorConfirm(messeges);
        }

        public bool ErrorAdults(string messeges)
        {
            return mainPage.GetErrorAdults(messeges);
        }

        public bool ErrorNameFrom(string messeges)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return mainPage.GetErrorNameFrom(messeges);
        }

        public bool ErrorEmptyData(string messeges)
        {
            return mainPage.GetErrorEmptyData(messeges);
        }

        public bool ErrorEmptyDataReturn(string messeges)
        {
            return mainPage.GetErrorEmptyDataReturn(messeges);
        }

        public void Return()
        {
            mainPage.ClickWay();
            mainPage.ClickReturn();
        }

        public void SetData(DateTime date)
        {
            mainPage.ClickData();
            mainPage.setData(date);
        }

    }
}
