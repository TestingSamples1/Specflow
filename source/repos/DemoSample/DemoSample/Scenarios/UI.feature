@Regression
Feature: UI

Background:
	Given I navigate to the url


@smoke navigation
Scenario:Validate navigation for news page
When I click on the 'new' link
Then 'New Links' page details should display

@smoke navigation
Scenario:Validate navigation for comments page
When I click on the 'comments' link
Then 'New Comments' page details should display

@smoke navigation
Scenario:Validate navigation for ask page
When I click on the 'ask' link
Then 'Ask' page details should display


@smoke navigation
Scenario:Validate navigation for show page
When I click on the 'show' link
Then 'Show' page details should display

@smoke navigation
Scenario:Validate navigation for jobs page
When I click on the 'jobs' link
Then 'jobs' page details should display

@smoke navigation
Scenario:Validate navigation for past page
When I click on 'past' link
Then I should navigate into 'past' page

@smoke navigation
Scenario:Validate navigation for submit page
When I click on 'submit' link
Then I should navigate into 'submit' page


