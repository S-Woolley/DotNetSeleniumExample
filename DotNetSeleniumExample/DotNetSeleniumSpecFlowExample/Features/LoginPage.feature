Feature: LoginPage

Site application login page.

Scenario: Login With No UserName or Password
	Given A login page
	When The login button is clicked
	Then an error message is displayed
	And error message should say 'Epic sadface: Username is required'

Scenario: Login With No Password
	Given A login page
	And  'standard-user' is entered for the username
	When The login button is clicked
	Then an error message is displayed
	And error message should say 'Epic sadface: Password is required'

Scenario: Login With No UserName
	Given A login page
	And  'secret-sauce' is entered for the password
	When The login button is clicked
	Then an error message is displayed
	And error message should say 'Epic sadface: Username is required'

Scenario: Login With Incorrect Password
	Given A login page
	And  'standard-user' is entered for the username
	And  'whatever' is entered for the password
	When The login button is clicked
	Then an error message is displayed
	And error message should say 'Epic sadface: Username and password do not match any user in this service'