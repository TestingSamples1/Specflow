using System;
using DemoSample.Common;
using DemoSample.Pages;
using TechTalk.SpecFlow;

namespace DemoSample
{
    [Binding]
    public class GoogleTestsSteps
    {
        private PageObjectFactory _page;
        public GoogleTestsSteps(PageObjectFactory page)
        {
            _page = page;
        }

        [Given(@"I navigate into url")]
        public void GivenINavigateIntoUrl()
        {
            BasePage.NavigateUrl(AppConfigManager.GetBaseUrl());
        }

        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(string gbpValue)
        {
            _page.homePage().Search(gbpValue);
        }

        [Then(@"I validate details")]
        public void ThenIValidateDetails()
        {
            _page.homePage().Validate();
        }
    }
}
