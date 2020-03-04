using DemoSample.Common;
using DemoSample.Pages;
using System;
using TechTalk.SpecFlow;

namespace DemoSample
{
    [Binding]
    public class SignUpSteps
    {
        private PageObjectFactory _page;
        public SignUpSteps(PageObjectFactory page)
        {
            _page = page;
        }

        [Given(@"I navigate to the url")]
        public void GivenINavigateToTheUrl()
        {
            BasePage.NavigateUrl(AppConfigManager.GetBaseUrl());
        }
        
       
        [Given(@"I enter name as '(.*)' and '(.*)'")]
        public void GivenIEnterNameAsAnd(string uname, string password)
        {
            _page.loginPage().EnterLoginDetails(uname, password);
        }

        [Given(@"I enter details")]
        public void GivenIEnterDetails()
        {
            _page.loginPage().CreateAccount();  
        }
    }
}
