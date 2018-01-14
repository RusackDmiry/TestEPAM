using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace NunitTestFramework.Pages
{
    /// <summary>
    /// Класс главной страницы сайта.
    /// </summary>
    public class MainPage : BasePage
    {
        private const string BaseUrl = "https://www.amtrak.com/home";

        #region Route Elements

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[2]/div/div[1]/div/div/div/input[2]")]
        private IWebElement inputFrom;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[2]/div/div[2]/div/div/div/input[2]")]
        private IWebElement inputTo;

        [FindsBy(How = How.XPath, Using = "//*[@id='findtrains']")]
        private IWebElement buttonSerch;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[2]/div/div[2]/div/div/div/span[3] ")]
        private IWebElement errorMessengNameTo;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[2]/div/div[1]/div/div/div/span[3]")]
        private IWebElement errorMessengNameFrom;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[2]/div/div[3]/span")]
        private IWebElement errorMessengConfirm;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[3]/div[1]/div/div[1]/div/div[1]/div/span")]
        private IWebElement errorMessengEmptyData;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[3]/div[2]/div/div/div/div[1]/div[2]/span")]
        private IWebElement errorMessengEmptyDataReturn;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[4]/div[2]/div[1]/ul/li[9]/span[2]")]
        private IWebElement errorMessengAdults;
        

      [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]")]
        private IWebElement title;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[1]/div/div[1]/div[1]/span[1]")]
        private IWebElement buttonForClick;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[1]/div/div[2]/ul/li[2]")]
        private IWebElement buttonReturn;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[3]/div[1]/div/div[1]/div/div[1]/div/div[2]")]
        private IWebElement buttonData;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[4]/div[1]")]
        private IWebElement buttonTravaler;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[4]/div[2]/div[1]/ul/li[2]/div/div[1]/input")]
        private IWebElement inputAdults;
        
        #endregion



        private IWebDriver driver;
        private SelectElement select;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Url = BaseUrl;
        }

        public void SerchClick()
        {
            buttonSerch.Click();
        }

        public void ClickWay()
        {
            buttonForClick.Click();
        }

        public void ClickReturn()
        {
            buttonReturn.Click();
        }

        public void ClickData()
        {
            buttonData.Click();
        }

        public void ClickTravaler()
        {
            buttonTravaler.Click();
        }

        public void setData( DateTime date)
        {
            string dayNumberAsString = date.Day.ToString();
            IWebElement dayButton = driver.FindElement(By.XPath("/html/body/div[2]/main/section[2]/div[1]/article/div[2]/div/div/form/div/div[3]/div[1]/div[3]/div[1]/div/div[1]/div/div[2]/div/div[2]/div/div/div[3]/span[24]"));
            dayButton.Click();
            
        }

        public void InputStation(string from, string to)
        {
            inputTo.Clear();
            inputTo.SendKeys(to);
            inputFrom.Clear();
            inputFrom.SendKeys(from);
        }

        public void InputAdults(int count)
        {
            inputAdults.Clear();
            inputAdults.SendKeys(Convert.ToString(count));
        }

        #region Error messages


        public bool GetErrorNameTo(string message)
        {
            return errorMessengNameTo.Text == message;
        }

        public bool GetErrorNameFrom(string message)
        {
            return errorMessengNameFrom.Text == message;
        }

        public bool GetErrorConfirm(string message)
        {
            title.Click();
            return errorMessengConfirm.Text == message;
        }

        public bool GetErrorEmptyData(string message)
        {
            return errorMessengEmptyData.Text == message;
        }

        public bool GetErrorEmptyDataReturn(string message)
        {
            return errorMessengEmptyDataReturn.Text == message;
        }

        public bool GetErrorAdults(string message)
        {
            return errorMessengAdults.Text == message;
        }
        #endregion
    }
}
