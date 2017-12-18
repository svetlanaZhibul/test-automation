using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Selenium.Chromedriver;
using Selenium.Chromedriver.Pages;

namespace NUnit.Selenium.Chromedriver
{
    [TestFixture]
    public class HomePageTest : AnyPageTest
    {
        private static string TruePswd = "testit";
        private static string TrueEmail = "3hibul@mail.ru";

        [Test]
        public void Logout()
        {
            var home = (new MainPage(driver)).Open().GoToLogin().Open().Login(TrueEmail, TruePswd).Open();

            var main = home.Logout();

            Driver.SetWaitTime(60);

            Assert.AreEqual(driver.Url, main.Url);
        }
    }
}
