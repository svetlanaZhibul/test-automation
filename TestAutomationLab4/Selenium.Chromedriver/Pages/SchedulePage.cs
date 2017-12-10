using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium.Chromedriver.Pages
{
    public class SchedulePage : AnyPage
    {
        public SchedulePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "ctf-results")]
        public IWebElement SearchResultsDiv;

        
    }
}
