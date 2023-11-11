Feature: Login into the app
Login into todo.ly app and assert

@create.project.errands
Scenario: Succesfully Login as User
	Given the user logs in to the baseURL as "adminuser"
	Then the user should be logged in
