Feature: Item CRUD Actions
The user creates a new item with a name

Background: 
	Given the user logs in to the baseURL as "adminuser"

@create.project.Homework
Scenario: Create a new item
	Given The user creates a new item named "Pasta" in the current project
	Then The new item should be created

@create.project.Work
@create.item.Tasks
Scenario: Delete an item
	Given The user opens the Options Menu in the "current" item
	When The user select the "Delete" option in the options menu
	Then The item should be deleted

@create.project.Homework
@create.item.Programming
Scenario: Set the priority of item
	Given The user opens the Options Menu in the "current" item
	When The user set the Priority of the item to "1" in the options menu
	Then The item should set in the assigned priority
