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
                   _driver =  ChromeDriver();
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

        private static IWebDriver ChromeDriver()
        {
             var options = new ChromeOptions { PageLoadStrategy = PageLoadStrategy.Normal };
            options.AddUserProfilePreference("profile.managed_default_content_settings.notifications", 2);
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            options.AddArguments(new List<string>() {
                   "no-sandbox",
                   "-incognito"
                });
                chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
            
            _driver = new ChromeDriver(chromeDriverService, options);

            return _driver;
        }
    }
}
