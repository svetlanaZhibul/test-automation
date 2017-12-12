using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Chromedriver.Pages
{ 
    public class HomePage : MainPage
    {
        private static string URL = "https://ojp.nationalrail.co.uk/personal/home/search";

        public string Url { get { return URL; } }

        [FindsBy(How = How.Id, Using = "dd-trig")]
        public IWebElement Greeting;

        [FindsBy(How = How.XPath, Using = "//a[contains( text(),'Sign out')]")]
        public IWebElement LogoutButton;
        
        public HomePage(IWebDriver driver) : base(driver) { }

        public void ClickExitButton()
        {
            LogoutButton.Click();
        }

        public MainPage Logout()
        {
            Greeting.Click();
            ClickExitButton();
            return PageFactory.InitElements<MainPage>(driver);
        }

        public HomePage Open()
        {
            driver.Navigate().GoToUrl(URL);
            return this;
        }
    }
}
