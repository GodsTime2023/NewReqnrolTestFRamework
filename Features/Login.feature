Feature: Login

As a user i want to be able to login
Add products to cart and verify total counts of product added to cart
Then logout

Rule: Add specific products to cart
	The below scenario uses a mechanism that
	only adds specify products by name
	and then verify the same products in the assertion.
@one
Scenario: Add product to basket (Example 1)
	Given user is on saucedemo login page
	When user enters login credentials
	| username       | password      |
	| standard_user  | secret_sauce  |
	Then user is logged in
	And the current url contain 'inventory'
	When I add the following products
	| productName           |
	| Sauce Labs Backpack   |
	| Sauce Labs Bike Light |
	And I view the basket
	Then I verify product count is 2
	And I verify product names as
	| productName           |
	| Sauce Labs Backpack   |
	| Sauce Labs Bike Light |


Rule: Add products at random
	The below scenario uses a mechanism 
	that adds product at random such that 
	if you specify 1 or 2 or 6 in the amount of products
	to be added then you should be able to verify the
	exact same products.
@two
Scenario: Add product to basket (Example 2)
	Given user is on saucedemo login page
	When user enters login credentials
	| username      | password     |
	| standard_user | secret_sauce |
	Then user is logged in
	And the current url contain 'inventory'
	When I save product names as "products"
	And I add 6 products to cart
	And I view the basket
	Then I verify product count is 6
	And I verify 6 product names from "products"