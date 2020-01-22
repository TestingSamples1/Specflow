using System;
using DemoSample.Common;
using DemoSample.Pages;
using TechTalk.SpecFlow;

namespace DemoSample
{
    [Binding]
    public class VerifyUSDSteps
    {
        private PageObjectFactory _page;
        public VerifyUSDSteps(PageObjectFactory page)
        {
            _page = page;
        }

        [Given(@"I navigate into google url")]
        public void GivenINavigateIntoGoogleUrl()
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
