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


        private static string TruePswd = "SomeCorrectPswd";
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

            Assert.AreEqual(driver.Url, home.Url);
        }

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