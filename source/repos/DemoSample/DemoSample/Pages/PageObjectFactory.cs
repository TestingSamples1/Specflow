using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoSample.Pages
{
    public class PageObjectFactory
    {
        public IWebDriver _driver;
        public BasePage _basePage;
        public PageObjectFactory(IWebDriver driver, BasePage basePage)
        {
            _driver = driver;
            _basePage = basePage;
        }
       
        public LoginPage loginPage()
        {
            return _basePage.GetPage<LoginPage>(_driver);
        }

        public HomePage homePage()
        {
            return _basePage.GetPage<HomePage>(_driver);
        }
    }
}
