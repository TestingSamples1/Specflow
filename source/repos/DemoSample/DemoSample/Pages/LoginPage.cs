using DemoSample.CoreUI;
using DemoSample.Extensions;
using DemoSample.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSample.Pages
{
    public class LoginPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region loginPageElements

        [FindsBy(How = How.LinkText, Using = "login")]
        private IWebElement loginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(text(), 'username')][last()]")] //"//input[@name='acct'][2]")]
        private IWebElement newUserNameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='pw'][2]")]
        private IWebElement newPassword { get; set; }


        [FindsBy(How = How.Name, Using = "create account")]
        private IWebElement createAccount { get; set; }

        #endregion

        #region loginPageActions
        public void EnterLoginDetails(string name, string password)
        {
            loginButton.Click();
            newUserNameField.WaitUntilDisplayed(2);
            newUserNameField.EnterText(name);
            newPassword.EnterText(password);
            createAccount.Click();
        }

        public void CreateAccount()
        {
            string name = TestData.TestData.GenerateName(4);
            loginButton.Click();
            newUserNameField.WaitUntilDisplayed(2);
            newUserNameField.EnterText(name);
            newPassword.EnterText("password");
            createAccount.Click();
        }
        #endregion

    }
}
