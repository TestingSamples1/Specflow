using DemoSample.Pages;
using System;
using TechTalk.SpecFlow;

namespace DemoSample
{
    [Binding]
    public class UISteps
    {
        private PageObjectFactory _page;
        public UISteps(PageObjectFactory page)
        {
            _page = page;
        }

        [When(@"I click on the '(.*)' link")]
        public void WhenIClickOnTheLink(string linkName)
        {
            _page.homePage().clickMenu(linkName);
        }

        [Then(@"'(.*)' page details should display")]
        public void ThenPageDetailsShouldDisplay(string pageDetails)
        {
            _page.homePage().verifyPageDetails(pageDetails);
        }


    }
}
