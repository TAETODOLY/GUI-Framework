Feature: Create a New Item
The user creates a new item with a name

Background: 
	Given the user logs in to the baseURL as "adminuser"

@create.project.Homework
Scenario: Create a new item
	Given The user creates a new item named "Pasta" in the current project
	Then The new item should be created
