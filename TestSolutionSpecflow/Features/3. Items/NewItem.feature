Feature: Create a New Item
The user creates a new item with a name

Background: 
	Given the user logs in to the baseURL as "adminuser"

@create.project.Errands
Scenario: Create a new item
	Given The user creates a new item named "Pasta"
	Then The new item should be created
