Feature: ChangeUsername
	Verify that the registered 
	user can change the user name

Scenario: Change Username
	Given I have navigated to the Edit Profile page
	And Changed my user name to "Saul"
	Then should appear pop-up window "Username is changed"