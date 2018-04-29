Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: As User I want verify that main page is available just by https.
	Given Not logged in user
	When I enter http://omada.net page 
	Then I expect to be redirected to page https://www.omada.net/ with title Identity Management | Omada Identity

Scenario: As User I search gartner from home page and check search results
	Given User at home page 
	When I search for gartner
	Then I expect to be redirected to page https://www.omada.net/en-us/search?q=gartner with title Search
	And I expect to see more than 1 search results
	And I expect to see There is Safety in Numbers title in these search results

Scenario: As User navigate to search results page and check it
	Given User at https://www.omada.net/en-us/search?q=gartner page 
	When Click on the link with text Gartner IAM Summit 2016 - London
	Then I expect to be at page with gartner-iam-summit-2016-london part in url
	And I expect to be at page with header type h1 contains string Gartner IAM Summit 2016 - London at least 1 times

Scenario: As User navigate to news category and check 
	Given User at https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london page 
	When Click in breadcrumps block on the link with text News
	Then I expect to be redirected to page https://www.omada.net/en-us/more/news-events/news with title News | Omada Identity Suite
	And I expect to be at page with header type h1 contains string Gartner IAM Summit 2016 - London at least 1 times

Scenario: As User with maximize browser window size navigate to news category and check
	Given User at https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london page
	And User maximized browser window size to maximize
	When Click in breadcrumps block on the link with text News
	Then I expect to be redirected to page https://www.omada.net/en-us/more/news-events/news with title News | Omada Identity Suite
	And I expect to be at page with header type h1 contains string Gartner IAM Summit 2016 - London at least 1 times
