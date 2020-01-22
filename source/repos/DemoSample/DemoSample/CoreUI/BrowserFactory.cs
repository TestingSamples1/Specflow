using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoSample.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoSample.CoreUI
{
 public   class BrowserFactory
    {
        public static IWebDriver _driver;
        public static TimeSpan _impTime = AppConfigManager.ImplictWaitPeriod();

        public static IWebDriver IntializeBrowser(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                case "FireFox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = _impTime;
            return _driver;
        }
    }
}
