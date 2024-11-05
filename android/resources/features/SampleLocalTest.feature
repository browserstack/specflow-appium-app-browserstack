@sample-local-test
Feature: BrowserStack Local Testing
	Scenario Outline: BStack Local Test - Can check tunnel working
		Given I start test on the Local Sample App
		Then I should see "Up and running"
