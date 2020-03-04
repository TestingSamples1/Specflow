Feature: News

Background:
	Given I logged into the website

@news Regression
Scenario: Validate search functionality
	Given I enter search critria as 'gov'
	When I click search
	Then I should get all the results

Scenario: Search filter validation for comments
	Given I enter search critria as 'gov'
	When I click search
	And I filter search for 'comments'
	Then I verify the search criteria is highlighting
	And it's displaying all the comments

	Scenario: Search filter validation for stories
	Given I enter search critria as 'gov'
	When I click search
	And I filter search for 'stories'
	Then I verify the search criteria is highlighting
	And it's displaying all the comments

Scenario: Search filter validation for date
	Given I enter search critria as 'gov'
	When I click search
	And I filter search for 'dates'
	Then I verify the results are sorted in date order


