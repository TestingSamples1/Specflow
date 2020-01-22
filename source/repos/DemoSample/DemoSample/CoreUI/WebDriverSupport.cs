using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoSample.Common;
using OpenQA.Selenium;

namespace DemoSample.CoreUI
{
    public class WebDriverSupport
    {
        private static IWebDriver _driver;
        private Stopwatch Watch { get; set; }
        public static IWebDriver SupportDriver()
        {
            return _driver;
        }

        public static void DisposeDriver()
        {
            _driver.Dispose();
            _driver.Quit();
            _driver.Close();
        }

        public static IWebDriver LaunchDriver()
        {
            _driver = BrowserFactory.IntializeBrowser(AppConfigManager.GetBrowser());
            return _driver;
        }

        public void EnterText(IWebElement element, string text)
        {
            WaitUntilElementDisplayed(element);
            //if (clearBeforeTyping) element.Clear();
            element.SendKeys(text);
        }



        public bool WaitUntilElementDisplayed(IWebElement element, int timeout = 60)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            Watch = new Stopwatch();
            Watch.Start();
            var elementDisplayed = false;
            while (Watch.Elapsed.TotalMilliseconds <= timeout * 1000 && !elementDisplayed)
            {
                try
                {
                    if (element.Displayed)
                    {
                        elementDisplayed = true;
                    }
                }
                catch
                {
                    //Ignored
                }
            }

            _driver.Manage().Timeouts().ImplicitWait = AppConfigManager.ImplictWaitPeriod();
            return elementDisplayed;
        }


        //public void EnterText(IWebElement e,string text)
        //{
        //    e.Clear();
        //    e.SendKeys(text);
        //}



    }
}
