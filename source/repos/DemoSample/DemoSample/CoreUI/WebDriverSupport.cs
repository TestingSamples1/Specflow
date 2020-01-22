using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoSample.Common;
using OpenQA.Selenium;
using Protractor;

namespace DemoSample.CoreUI
{
    public class WebDriverSupport
    {
        private static NgWebDriver _ngDriver;
        private static IWebDriver _driver;
        private Stopwatch Watch { get; set; }
        public static IWebDriver SupportDriver()
        {
            return _driver;
        }
        public static NgWebDriver NgWebDriver()
        {
            return _ngDriver;
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
            _ngDriver = NewNgDriver();

            return _driver;
        }

        public static NgWebDriver NewNgDriver()
        {
            var newNgDriver = new NgWebDriver(_driver);
            newNgDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            newNgDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            newNgDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            return newNgDriver;
        }


        //public void AngularWait(int timeout = 30)
        //{
        //    Watch = new Stopwatch();
        //    Watch.Start();
        //    _ngDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(timeout);
        //    _ngDriver.WaitForAngular();
        //    _ngDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
        //    var elapsed = Watch.Elapsed.TotalSeconds;
           
        //}

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
