using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NUnitChromeDriver.Pages
{
    public class HomePage : AnyPage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "login-username")]
        public IWebElement UsernameField;


        [FindsBy(How = How.Id, Using = "login-password")]
        public IWebElement PasswordField;


        [FindsBy(How = How.Id, Using = "btn-login")]
        public IWebElement SubmitButton;
        
        public HomePage LoginAsUser(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            SubmitButton.Submit();
            return this;
        }
    }
}
