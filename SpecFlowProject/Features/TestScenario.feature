Feature: WebAPI testing



Scenario: 1 Upload a file
	Given the file is to be uploaded
	When the file is uploaded
	Then the uploading should be successful


Scenario: 2 Get the file meta data
	Given the file to receive the meta data of
	When the meta data is received
	Then the meta data should be received


Scenario: 3 Delete the file
	Given the file to be deleted
	When the file is deleted
	Then the deleting should be successful