using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoSample.CoreUI;
using OpenQA.Selenium;

namespace DemoSample.Extensions
{
    public static class WebElementExtensions
    {
        public static bool WaitUntilDisplayed(this IWebElement e, int timeout = 60)
        {
            var watch = new Stopwatch();
            var driver = WebDriverSupport.SupportDriver();
            return WaitUntilDisplayed(e, timeout);
        }
        //public static void AngularClickElement(this IWebElement e)
        //{
        //    WebDriverSupport.NgWebDriver().WaitForAngular();
        //    e.ClickElement();
        //    WebDriverSupport.NgWebDriver().WaitForAngular();
        //}


        public static void ClickElement(this IWebElement e)
        {
            if (!e.WaitUntilDisplayed(5)) return;
            e.Click();
        }
    }
}
