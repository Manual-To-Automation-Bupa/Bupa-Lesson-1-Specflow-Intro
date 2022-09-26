Feature: BrowserStack Login
In order to learn how to automate
As a manual tester
I want to open a webpage and interact with elements
So that reason
 
Scenario: Go to BrowserStack website and login
 Given I navigate to the "https://browserstack.com" website
 When I navigate to the Sign In page
 When I enter the correct username and password
 Then I have logged in successfully