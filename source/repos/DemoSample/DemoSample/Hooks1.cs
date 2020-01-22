using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using DemoSample.CoreUI;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DemoSample
{
    [Binding]
    public sealed class Hooks1 : IDisposable
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        private static IWebDriver _currentDriver;
        private static IObjectContainer _iObjectContainer;

        public Hooks1(IObjectContainer objectContainer)
        {
            _iObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            _currentDriver = WebDriverSupport.LaunchDriver();
            _iObjectContainer.RegisterInstanceAs<IWebDriver>(_currentDriver);

        }

        public void Dispose()
        {
            _currentDriver?.Dispose();

        }
    }
}
