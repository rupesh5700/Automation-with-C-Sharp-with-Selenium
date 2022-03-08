using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ICICI.POM
{
    public class LogIn
    {
        public IWebDriver Driver { get; private set; }

        [FindsBy(How =How.Name, Using = "q")]
        public IWebElement GoogleSertch { get;  set; }

       
        [Obsolete]
        public LogIn(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }


        public void Googletext() {
            GoogleSertch.SendKeys("Software");   
        }

    }
}
