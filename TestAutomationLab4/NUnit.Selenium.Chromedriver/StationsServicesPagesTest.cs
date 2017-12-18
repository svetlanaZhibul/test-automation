using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Chromedriver;
using Selenium.Chromedriver.Pages;

namespace NUnit.Selenium.Chromedriver
{
    [TestFixture]
    class StationsServicesPagesTest : AnyPageTest
    {
        private static string DefaultURL = "http://www.nationalrail.co.uk/stations_destinations/default.aspx";
        private static string KemsingStUrl = "http://www.nationalrail.co.uk/stations/KMS/details.html";
        private static string KemsingCity = "Kemsing";
        private static string LondonCity = "London";
        private static string InvalidCity = "Abrakadabra";
        private static string ErrorMessege = "Sorry, no matching stations found.";
        private static string WarnMessege = "Station is too ambiguous, please choose from the list below.";

        private static StationsServicesPage page;

        //[SetUp]
        //public void InitPage()
        //{
        //    var page = (new StationsServicesPage(driver)).Open(DefaultURL);
        //    Driver.SetWaitTime(80);

        //    page.StationField = driver.FindElement(By.XPath("//*[@name='findStationForm']//input[@id='station']"));

        //    page.FindServiceButton = driver.FindElement(By.XPath("//*[@name='findStationForm']//button[@value='Search']"));
        //}

        [Test]
        public void GetServicesForKemsingStation()
        {
            var page = (new StationsServicesPage(driver)).Open(DefaultURL);

            //Driver.SetWaitTime(80);

            //IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            //js.ExecuteScript($"document.getElementById(\"{"station"}\").innerHTML = \"{KemsingCity}\";");
            //js.ExecuteScript($"document.getElementsByClassName(\"{"b-y"}\")[0].click();");

            page.StationField = driver.FindElement(By.XPath("//*[@name='findStationForm']//input[@id='station']"));

            page.FindServiceButton = driver.FindElement(By.XPath("//*[@name='findStationForm']//button[@value='Search']"));

            var result = page.FindStationService(KemsingCity);

            Driver.SetWaitTime(80);

            Assert.AreEqual(KemsingStUrl, driver.Url);
        }

        [Test]
        public void FailGetServicesForInvalidStation()
        {
            var page = (new StationsServicesPage(driver)).Open(DefaultURL);

            page.StationField = driver.FindElement(By.XPath("//*[@name='findStationForm']//input[@id='station']"));

            page.FindServiceButton = driver.FindElement(By.XPath("//*[@name='findStationForm']//button[@value='Search']"));

            var result = page.FindStationService(InvalidCity);

            Driver.SetWaitTime(80);

            Assert.AreEqual(result.ErrorMessege.Text, ErrorMessege);
        }

        [Test]
        public void FailGetServicesForCommonStationName()
        {
            var page = (new StationsServicesPage(driver)).Open(DefaultURL);

            page.StationField = driver.FindElement(By.XPath("//*[@name='findStationForm']//input[@id='station']"));

            page.FindServiceButton = driver.FindElement(By.XPath("//*[@name='findStationForm']//button[@value='Search']"));

            var result = page.FindStationService(LondonCity);

            Driver.SetWaitTime(80);

            Assert.AreEqual(result.ErrorMessege.Text, WarnMessege);
        }
    }
}
