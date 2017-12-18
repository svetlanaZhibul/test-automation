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
    public class SearchPageTest : AnyPageTest
    {
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
