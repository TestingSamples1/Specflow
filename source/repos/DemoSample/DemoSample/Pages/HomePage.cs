using DemoSample.CoreUI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSample.Pages
{
    public class HomePage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region homePageElements
        
        protected IWebElement UiLinks(string linkName) =>
            _driverSupport.FindNewElement(By.XPath($"//a[text() = '{linkName}']"));
        
        protected IWebElement pageDetail(string page) =>
           _driverSupport.FindNewElement(By.XPath($"//tr[contains(@id, 'pagespace')][contains(@title, 'New Links')]"));//"//tr[contains(@id, 'pagespace')][contains(@title, '{page}')]']"));
        
        #endregion

        #region homePageActions

        public void clickMenu(string menuName)
        {
            UiLinks(menuName).Click();
        }

        public void verifyPageDetails(string pageDescription)
        {
            Assert.IsTrue(pageDetail(pageDescription).Displayed);
        }
        #endregion
    }
}
