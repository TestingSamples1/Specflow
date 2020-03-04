Feature: SignUp

Background:
	Given I navigate to the url

@SignUp
Scenario: Sign up
	Given I enter details
	When I create a new account
	Then I should logged in to my account

@suite:LogIn
Scenario: Log into an Existing Account
	Given I enter name as 'Tuelyss' and 'password'
	Then I should logged in to my account

@Regression
Scenario: Reset Password Successful
	Given I select option for forgot password
	And I enter my username as 'Tuelytest'
	When I click send reset email
	Then I should get a sucess message

Scenario: Logout
	When I click on logout
	Then I should see the login button