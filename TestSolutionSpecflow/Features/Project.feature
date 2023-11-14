Feature: Make a new Project
Create a new Project

Background: 
	Given the user logs in to the baseURL as "adminuser"

@tag1
Scenario: Succesfully create a New Project
	Given the user clicks on the "Add New Project" button
	When the user creates a new project called "Specflow"
	Then a New Project should be created
