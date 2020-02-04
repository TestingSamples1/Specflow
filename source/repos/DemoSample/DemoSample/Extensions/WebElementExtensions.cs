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
            return WaitHandler(e, timeout, ElementOptions.Displayed);
        }

        public static void ClickElement(this IWebElement e)
        {
            if (!e.WaitUntilDisplayed(5)) return;
            try
            {
                e.Click();
            }
            catch (Exception exception)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriverSupport.SupportDriver();
                executor.ExecuteScript("arguments[0].click();", e);
            }
        }

        public static void EnterTextIntoField(IWebElement element, string text, bool clearBeforeTyping = true)
        {
            WaitUntilDisplayed(element);
            if (clearBeforeTyping) element.Clear();
            element.SendKeys(text);
        }

        private enum ElementOptions
        {
            Displayed,
            NotDisplayed,
            Enabled,
        }
        private static  bool WaitHandler(IWebElement e, int timeout, ElementOptions option, string text = "")
        {
            var watch = new Stopwatch();
            var driver = BrowserFactory._driver;
            var result = false;
            watch.Start();
            while (watch.Elapsed.TotalMilliseconds <= timeout)
            {
                try
                {
                    switch (option)
                    {
                        case ElementOptions.Displayed:
                            if (e.Displayed)
                            {
                                result = true;
                            }

                            break;

                        default:
                            break;
                    }
                }
                catch (Exception exception)
                {
                    //ignore
                }
            }
            return  result;
        }
    }
}
