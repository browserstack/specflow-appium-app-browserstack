@sample-test
Feature: BrowserStack Demo
	Scenario Outline: BStack Sample Test - Search BrowserStack
		Given I try to search using Wikipedia App
		Then I search with keyword BrowserStack
		Then The search results should be listed
