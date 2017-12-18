using NUnit.Framework;
using Selenium.Chromedriver;
using Selenium.Chromedriver.Pages;

namespace NUnit.Selenium.Chromedriver
{
    [TestFixture]
    public class ScheduleTest : AnyPageTest
    {
        private static string wedTrainUrl = "https://ojp.nationalrail.co.uk/service/timesandfares/London/GLC/131217/2000/dep";

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
    }
}
