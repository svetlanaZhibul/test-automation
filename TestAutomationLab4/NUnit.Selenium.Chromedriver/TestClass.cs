﻿using NUnit.Framework;
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


        private static string TruePswd = "testit";
        private static string TrueEmail = "3hibul@mail.ru";
        private static string FakeEmail = "some@fake";
        private static string FakePswd = "pswdddd";

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

        [Test]
        public void Login()
        {
            var main = new MainPage(driver);
            var home = main.Open().GoToLogin().Open().Login(TrueEmail, TruePswd).Open();

            Driver.SetWaitTime(60);

            Assert.IsNotNull(home.LogoutButton);
        }

        [Test]
        public void SearchForTrain()
        {
            string from = "London";
            string to = "Glasgow Central";
            string when = "13/12/17";
            string h_time = "20";
            string m_time = "00";

            var main = new MainPage(driver);
            var shedule = main.Open().FindSchedule(from, to, when, h_time, m_time);

            driver.Navigate().GoToUrl(wedTrainUrl);

            Driver.SetWaitTime(60);

            Assert.AreEqual(driver.Url, wedTrainUrl);
        }

        [Test]
        public void FailLogin()
        {
            var main = new MainPage(driver);
            var login = main.Open().GoToLogin().Open().FailLogin(FakeEmail, FakePswd);

            Driver.SetWaitTime(60);

            Assert.AreEqual(login.ErrorMessage.Text, "This email address or password has not been recognised. Please re-enter.");
        }

        [Test]
        public void Logout()
        {
            var home = (new MainPage(driver)).Open().GoToLogin().Open().Login(TrueEmail, TruePswd).Open();

            var main = home.Logout();

            Driver.SetWaitTime(60);

            Assert.AreEqual(driver.Url, main.Url);
        }

        [Test]
        public void NewsSearch()
        {
            string query = "london";
            NewsSearchPage searchPage = new NewsSearchPage(driver);
            driver.Navigate().GoToUrl(searchPage.Url);

            Driver.SetWaitTime(60);

            searchPage.DoSearch(query);
            driver.Navigate().GoToUrl(searchPage.Url + searchPage.UrlQuery + query);

            Assert.IsTrue(searchPage.SearchResultText.Text.Contains("We found"));
        }
    }
}
