using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoSample.Common;
using OpenQA.Selenium;
using Protractor;
using DemoSample.Extensions;

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

        public IWebElement FindNewElement(By by, int timeout = 10)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

            try
            {
               return _driver.FindElement(by);
            }
            catch (Exception e)
            {
                return default(IWebElement);
            }
            finally
            {
                _driver.Manage().Timeouts().ImplicitWait = AppConfigManager.ImplictWaitPeriod();
            }
        }

    }
}
