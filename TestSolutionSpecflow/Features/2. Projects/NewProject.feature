Feature: Create a new Project
The user creates a new project with a name

Background: 
	Given the user logs in to the baseURL as "adminuser"

Scenario: Create a new project
	Given The user clicks on "Add New Project" button in the left navigation bar
	When The user creates a new project named "Errands"
	Then The new project should be created