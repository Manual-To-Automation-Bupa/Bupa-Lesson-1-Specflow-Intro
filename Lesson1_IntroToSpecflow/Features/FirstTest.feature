Feature: First Test
  In order to learn how to automate
  As a manual tester
  I want to open a webpage and interact with elements
 
Scenario: Go to BrowserStack sign in page
  Given I go to the "https://browserstack.com" website
  When I click on the Sign In button
  Then I should see the Sign In page