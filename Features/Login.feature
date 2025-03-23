Feature: Login

As a user i want to be able to login


@one
Scenario: Valid Login Test
	Given user is on saucedemo login page
	When user enters login credentials
	| username       | password      |
	| standard_user  | secret_sauce  |
	Then user is logged in
	And the current url contain 'inventory'

@two
Scenario: Valid Login Test2
	Given user is on saucedemo login page
	When user enters login credentials
	| username      | password     |
	| standard_user | secret_sauce |
	Then user is logged in
	And the current url contain 'inventory'