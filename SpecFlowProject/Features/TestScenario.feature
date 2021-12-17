Feature: OrangeHRM Selenium testing var 3



Scenario: 1 Sign in to the OrangeHRM
	Given the username is Admin
	And the password is admin123
	When the submit is clicked
	Then the signing in should be successful



Scenario: 2 Adding a new record to Pay Grades Page
	Given the name of the record to be created is IlliaMamonov
	And the minimum salary is 100 and the maximum salary is 5000
	When the record is being looked for
	Then the record should be found



Scenario: 3 Deleting a record from Pay Grades Page
	Given the record name to be deleted is IlliaMamonov
	When the record is deleted
	Then the record should not appear on the pay grades page