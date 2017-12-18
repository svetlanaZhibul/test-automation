using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium.Chromedriver.Pages
{
    public class StationsServicesPage : AnyPage
    {
        private string Url { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='station']")]
        public IWebElement StationField;

        [FindsBy(How = How.XPath, Using = "//*[@name='findStationForm']//button[@value='Search']")]
        //[FindsBy(How = How.ClassName, Using = "b-y")]
        public IWebElement FindServiceButton;

        [FindsBy(How = How.ClassName, Using = "error")]
        public IWebElement ErrorMessege;

        public StationsServicesPage(IWebDriver driver) : base(driver)
        {
        }

        public StationsServicesPage Open(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public void Find()
        {
            FindServiceButton.Click();
        }

        public StationsServicesPage FindStationService(string station)
        {
            StationField.Clear();
            StationField.SendKeys(station);
            FindServiceButton.Click();

            return PageFactory.InitElements<StationsServicesPage>(driver);
        }
    }
}
