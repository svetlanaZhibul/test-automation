using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Chromedriver.Pages
{
    public class AnyPage
    {
        protected IWebDriver driver;

        public AnyPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
