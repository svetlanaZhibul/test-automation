using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Chromedriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Chromedriver.Pages;

namespace NUnit.Selenium.Chromedriver
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver driver;
        private static string wedTrainUrl = "https://ojp.nationalrail.co.uk/service/timesandfares/London/GLC/131217/2000/dep";
        private static string explorerPageUrl = "https://www.tumblr.com/explore/trending";
        private static string postsByTagUrl = "https://www.tumblr.com/search/girl";
        private static string followWithoutRegisterUrl = "https://www.tumblr.com/register?redirect_to=/explore";
        private static string HomePageUrl = "https://ojp.nationalrail.co.uk/personal/home/search";
        private static string dashboardUrl = "https://www.tumblr.com/dashboard";

        private static string TruePswd = "testit";
        private static string TrueEmail = "3hibul@mail.ru";
        private static string FakeEmail = "https://www.tumblr.com/login";
        private static string FakePswd = "https://www.tumblr.com/dashboard";

        [SetUp]
        public void Init()
        {
            driver = Driver.Get();
        }

        [TearDown]
        public void Close()
        {
            Driver.Close();
        }

        //[Test]
        //public void AddPost()
        //{
        //    var enterPage = new EnterPage(driver);
        //    enterPage.Open().AddPost();

        //    Driver.SetWaitTime(60);

        //    Assert.AreEqual(driver.Url, dashboardUrl);
        //}

        //[Test]
        //public void OpenMainPage()
        //{
        //    var mainPage = new MainPage(driver);
        //    mainPage.Open();

        //    Assert.AreEqual(driver.Url, mainPageUrl);
        //}

        //[Test]
        //public void OpenExplorerPage()
        //{
        //    var explorerPage = new ExplorerPage(driver);
        //    explorerPage.Open();

        //    Assert.AreEqual(driver.Url, explorerPageUrl);
        //}

        //[Test]
        //public void OpenEnterPage()
        //{
        //    var enterPage = new EnterPage(driver);
        //    enterPage.Open();

        //    Assert.AreEqual(driver.Url, enterPageUrl);
        //}

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
            var home = main.Open().GoToLogin().Open().Login(FakeEmail, FakePswd).Open();

            Driver.SetWaitTime(60);

            Assert.IsNull(home.LogoutButton);
        }

        [Test]
        public void Logout()
        {
            var home = (new MainPage(driver)).Open().GoToLogin().Open().Login(TrueEmail, TruePswd).Open();

            var main = home.Logout();

            Driver.SetWaitTime(60);

            Assert.AreEqual(driver.Url, main.Url);
        }

        //[Test]
        //public void FindPostByTag()
        //{
        //    var mainPage = new MainPage(driver);
        //    mainPage.Open().FindPostsByTag();
        //    Driver.SetWaitTime(30);

        //    Assert.AreEqual(driver.Url, postsByTagUrl);
        //}

        //[Test]
        //public void Follow()
        //{
        //    var explorerPage = new ExplorerPage(driver);
        //    explorerPage.Open().Follow();

        //    Assert.AreEqual(driver.Url, followWithoutRegisterUrl);
        //}
    }
}
