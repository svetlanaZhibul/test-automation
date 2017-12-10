using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Chromedriver.Pages
{
    public class LoginPage : AnyPage
    {
        private static string URL = "https://ojp.nationalrail.co.uk/personal/login/secure";

        [FindsBy(How = How.Id, Using = "signinEmail")]
        public IWebElement EmailField;

        [FindsBy(How = How.Id, Using = "signinPword")]
        public IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "loginNow")]
        public IWebElement LoginButton;

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void EnterLogin(string login)
        {
            //EmailField.Clear();
            EmailField.SendKeys(login);
        }

        public void EnterPassword(string password)
        {
            //EmailField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public HomePage Login(string login, string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            ClickLoginButton();
            return PageFactory.InitElements<HomePage>(driver);
        }

        public LoginPage Open()
        {
            driver.Navigate().GoToUrl(URL);
            return this;
        }
    }
}
