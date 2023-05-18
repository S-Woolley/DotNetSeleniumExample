Feature: HomePage

Application Home Page

Scenario: Shopping Cart Badge Displayed And Shows Total When Item Added to Cart
	Given I am logged in as a standard user on the home page
	When I click add to cart for <item> 
	Then the checkout cart total equals '1'
Examples: 
| item                              |
| Sauce Labs Backpack               |
| Sauce Labs Fleece Jacket          |
| Test.allTheThings() T-Shirt (Red) |

Scenario: Shopping Cart Badge Displayed And Shows Total When Multiple Items Added to Cart
	Given I am logged in as a standard user on the home page
	When I click add to cart for <item> 
	And I click add to cart for <item2> 
	And I click add to cart for <item3> 
	Then the checkout cart total equals '3'
Examples: 
| item                | item2                   | item3                             |
| Sauce Labs Backpack | Sauce Labs Fleece Jacket| Test.allTheThings() T-Shirt (Red) |

Scenario: Logout
	Given I am logged in as a standard user on the home page
	When I click logout
	Then I am taken to the home page
