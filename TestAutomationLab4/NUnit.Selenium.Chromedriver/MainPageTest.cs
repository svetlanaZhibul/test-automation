using NUnit.Framework;
using Selenium.Chromedriver;
using Selenium.Chromedriver.Pages;

namespace NUnit.Selenium.Chromedriver
{
    [TestFixture]
    public class MainPageTest : AnyPageTest
    {
        private static string TruePswd = "testit";
        private static string TrueEmail = "3hibul@mail.ru";
        private static string FakeEmail = "some@fake";
        private static string FakePswd = "pswdddd";
               
        [Test]
        public void Login()
        {
            var main = new MainPage(driver);
            var home = main.Open().GoToLogin().Open().Login(TrueEmail, TruePswd).Open();

            Driver.SetWaitTime(60);

            Assert.IsNotNull(home.LogoutButton);
        }
        
        [Test]
        public void FailLogin()
        {
            var main = new MainPage(driver);
            var login = main.Open().GoToLogin().Open().FailLogin(FakeEmail, FakePswd);

            Driver.SetWaitTime(60);

            Assert.AreEqual(login.ErrorMessage.Text, "This email address or password has not been recognised. Please re-enter.");
        }        
    }
}
