Feature: Google search
    
Scenario: Search 'selenium webdriver' in Google search bar
    Given I have entered the Google Home Page
    And I see the page is loaded
    When I have entered selenium webdriver in the Search Text Box
    And I click on Search Button
    Then The result should be a new page with results for selenium webdriver   