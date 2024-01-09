Feature: Create a New Item
The user creates a new item with a name

Background: 
	Given the user logs in to the baseURL as "adminuser"
	Given The user clicks on "Add New Project" button in the left navigation bar
	When The user creates a new project named "Dinners"

@tag1
Scenario: Create a new item
	Given The user creates a new item named "Pasta"
	Then The new item should be created
