Feature: VerifyUSD
	Background: 
	Given I navigate into google url

@SmokeTest
Scenario: Validate USD value
	Given I search for 'GBP TO USD'
	Then I validate details