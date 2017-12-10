using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// login: https://ojp.nationalrail.co.uk/personal/login/secure
// id: dd-trig  - when signed in
// https://ojp.nationalrail.co.uk/service/planjourney/search


namespace Selenium.Chromedriver.Pages
{
    public class MainPage : AnyPage
    {
        private static string URL = "https://ojp.nationalrail.co.uk/service/planjourney/search";

        public string Url { get { return URL; } }

        [FindsBy(How = How.Id, Using = "sltArr")]
        public IWebElement TrainStateField;

        [FindsBy(How = How.Id, Using = "txtFrom")]
        public IWebElement FromField;

        [FindsBy(How = How.Id, Using = "txtTo")]
        public IWebElement ToField;

        [FindsBy(How = How.Id, Using = "txtDate")]
        public IWebElement DateField;
        
        [FindsBy(How = How.Id, Using = "sltHours")]
        public IWebElement HoursField;

        [FindsBy(How = How.Id, Using = "sltMins")]
        public IWebElement MinutesField;

        [FindsBy(How = How.Id, Using = "ret-ch")]
        public IWebElement ReturnCheckBox;

        [FindsBy(How = How.Id, Using = "sltArrRet")]
        public IWebElement ReturnTrainStateField;

        [FindsBy(How = How.Id, Using = "txtDateRet")]
        public IWebElement ReturnDateField;

        [FindsBy(How = How.Id, Using = "sltHoursRet")]
        public IWebElement ReturnHoursField;

        [FindsBy(How = How.Id, Using = "sltMinsRet")]
        public IWebElement ReturnMinutesField;

        [FindsBy(How = How.Id, Using = "chkTrains3")]
        public IWebElement FastTrainCheckBox;

        [FindsBy(How = How.Id, Using = "go")]
        public IWebElement GoButton;

        public MainPage(IWebDriver driver) : base(driver) { }

        public MainPage Open()
        {
            driver.Navigate().GoToUrl(URL);
            return this;
        }

        public void SetDate(string date = "Today")
        {
            DateField.Clear();
            DateField.SendKeys(date);
        }

        public void SetTrainState(string state = "Arrival")
        {
            TrainStateField.Clear();
            TrainStateField.SendKeys(state);
        }

        public void SetTime(int hours, int mins)
        {
            if (DateTime.Now.Hour > hours || (DateTime.Now.Hour == hours && DateTime.Now.Minute <= mins))
            {
                SetTime();
            }
            else 
            {
                HoursField.SendKeys(hours.ToString());
                MinutesField.SendKeys(mins.ToString());
            }
        }

        public void SetTime()
        {
            string hours, mins;

            if(DateTime.Now.Minute < 15)
            {
                hours = DateTime.Now.Hour.ToString();
                mins = "15";
            }
            else if (DateTime.Now.Minute < 30)
            {
                hours = DateTime.Now.Hour.ToString();
                mins = "30";
            }
            else if (DateTime.Now.Minute < 45)
            {
                hours = DateTime.Now.Hour.ToString();
                mins = "45";
            }
            else
            {
                mins = "00";
                hours = DateTime.Now.AddHours(1).Hour.ToString();
            }

            HoursField.SendKeys(hours);
            MinutesField.SendKeys(mins);
        }
        
        public void SetReturnToTrue()
        {
            ReturnCheckBox.SendKeys("true");
        }

        public LoginPage GoToLogin()
        {
            return PageFactory.InitElements<LoginPage>(driver);
        }

        public SchedulePage FindSchedule(string from, string to, string when, string h_time, string m_time)
        {
            FromField.SendKeys(from);
            ToField.SendKeys(to);
            DateField.SendKeys(when);
            HoursField.SendKeys(h_time);
            MinutesField.SendKeys(m_time);
            GoButton.Click();

            return PageFactory.InitElements<SchedulePage>(driver);
        }
    }
}
