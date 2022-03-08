using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ICICI.Generic_Library
{
    public class Utilities
    {
        public void NavigationBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public void NavigationForward(IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        public void Refresh(IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public void Scrolling(IWebDriver driver, int x, int y)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            //javaScriptExecutor.ExecuteScript("window.scollTo(" + x + ", " + y + ")");
            javaScriptExecutor.ExecuteScript("javascript:window.scrollBy(" + x + "," + y + ")");

        }

        public void SwitchToFrame(IWebDriver driver)
        {
            driver.SwitchTo().Frame(0);

        }

        public void SwitchBackToFrame(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public void MoveToElement(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);

        }

        public void DropDown(IWebDriver driver, IWebElement element)
        {
            SelectElement selectelement = new SelectElement(element);
            //selectelement.SelectByIndex(element);
        }
    }
}
