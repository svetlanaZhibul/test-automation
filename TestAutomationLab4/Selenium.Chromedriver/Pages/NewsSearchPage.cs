using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Chromedriver.Pages
{
    public class NewsSearchPage : AnyPage
    {
        private static string URL = "http://www.nationalrail.co.uk/search.aspx";
        private static string URLQuery = "?query=";

        public NewsSearchPage(IWebDriver driver) : base(driver) { }

        public string Url { get { return URL; } }
        public string UrlQuery { get { return URLQuery; } }

        [FindsBy(How = How.XPath, Using = "//*[@class=’box-6’]/div/p")]
        public IWebElement SearchResultText;

        [FindsBy(How = How.Id, Using = "search-results")]
        public IWebElement QueryField;

        [FindsBy(How = How.ClassName, Using = "b-y")]
        public IWebElement QueryGoButton;

        public void DoSearch(string query)
        {
            //QueryField.Clear();
            QueryField.SendKeys(query);
            QueryGoButton.Click();
        }
    }
}
