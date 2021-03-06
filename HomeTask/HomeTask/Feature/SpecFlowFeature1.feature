﻿Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: 1. As User I want verify that main page is available just by https.
	Given Not logged in user
	When I enter http://omada.net page 
	Then I expect to be redirected to page https://www.omada.net/ with title Identity Management | Omada Identity

# There is no search results with title "There is Safety in Numbers"
Scenario: 2. As User I search gartner from home page and check search results
	Given User at home page 
	When I search for gartner
	Then I expect to be redirected to page https://www.omada.net/en-us/search?q=gartner with title Search
	And I expect to see more than 1 search results
	And I expect to see There is Safety in Numbers title in these search results

Scenario: 3. As User navigate to search results page and check it
	Given User at https://www.omada.net/en-us/search?q=gartner page 
	When Click on the link with text Gartner IAM Summit 2016 - London
	Then I expect to be at page with gartner-iam-summit-2016-london part in url
	And I expect to be at page with header type h1 contains string Gartner IAM Summit 2016 - London at least 1 times

# Failed when user window width from 843px to 1009px, becourse breadcrumps hide
Scenario Outline: 4. As User navigate to news category and check 
	Given User at https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london page 
	And User use browser window with <width>px X <height>px size
	When Click in breadcrumps block on the News
	Then I expect to be redirected to page https://www.omada.net/en-us/more/news-events/news with title News | Omada Identity Suite
	And I expect to be at page with header type h1 contains string Gartner IAM Summit 2016 - London at least 1 times
Examples:
| width | height |
| 240   | 320    |
| 842   | 600    |
| 843   | 600    |
| 1009  | 600    |
| 1010  | 600    |

Scenario: 5. As User navigate to homepage by click on logo
	Given User at https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london page
	When Click on the element logo at the top
	Then I expect to be redirected to page https://www.omada.net/en-us with title Identity Management | Omada Identity

@Desktop
Scenario: 6. As User navigate to homepage by click on EN language flag for desktop
	Given User at https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london page
	When Click on the element EN language flag for desktop
	Then I expect to be redirected to page https://www.omada.net/en-us/omada-homepage with title Identity Management | Omada Identity

@Mobile
Scenario: 7. As User navigate to homepage by click on EN language flag for mobile
	Given User at https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london page
	And User use mobile browser window size
	When Click on the element mobile menu button
	And Navigate to the element EN language flag for mobile
	And Click on the element EN language flag for mobile
	Then I expect to be redirected to page https://www.omada.net/en-us/omada-homepage with title Identity Management | Omada Identity

	
@Desktop
Scenario Outline: 8. As desktop User navigate from home page to contact page and click tab and check if there is class change on this element (take a screenshot of that)
	Given User at home page
	And Click on the element Contacts button at the top desktop menu
	When Click in contacts for desktop block on the <ContactRegionButton>
	Then Taking screenshot of the entire screen saved with name s8-<ContactRegionButton>
Examples:
| ContactRegionButton |
| U.S. West   |

@Mobile
Scenario Outline: 9. As mobile User navigate from home to contact page and click tab and check if there is class change on this element (take a screenshot of that)
	Given User at home page
	And User use browser window with <width>px X <height>px size
	And Click on the element mobile menu button
	And Navigate to and click on the element contacts button in mobile menu
	When Navigate to and click in contacts for mobile block on the <ContactRegionButton>
	Then Taking screenshot of the entire screen saved with name s9-<ContactRegionButton>-<width>px_<height>px
Examples:
| ContactRegionButton | width | height |
| U.S. West   | 240   | 320    |
| U.S. East   | 799   | 600    |

@Desktop
Scenario Outline: 10. As desktop User on contact page do a mouse hover on different location (take a screenshot before and after performing the action)
	Given User at contact page
	And Click in contacts for desktop block on the <ContactRegionButtonStart>
	And Taking screenshot of the entire screen saved with name s10-<ContactRegionButtonStart>-to-<ContactRegionButtonSwitchTo>-before
	When Click in contacts for desktop block on the <ContactRegionButtonSwitchTo>
	Then Taking screenshot of the entire screen saved with name s10-<ContactRegionButtonStart>-to-<ContactRegionButtonSwitchTo>-after
Examples:
| ContactRegionButtonStart | ContactRegionButtonSwitchTo |
| U.S. West                | Denmark                     |
| U.S. West                | U.S. East                   |
| Denmark				   | U.S. West                   |
| U.S. West                | Germany                     |
| U.S. West                | UK                          |

@Desktop
Scenario: 11. Open Read Privacy Policy in another tab. Check if it is opened and loaded properly
	Given User at contact page
	When Open Privacy Policy at the bottom cookiebar in new tab
	Then I expect to be at page with title Omada | Processing of Personal Data
	And I expect to be at page with h1 header WEBSITE PRIVACY POLICY
	And I expect to be at page with text info@omada.net

@Desktop
Scenario: 12. Open Privacy Policy in another tab. Check if it is opened and loaded properly
	Given User at contact page
	When Open Privacy Policy at the footer in new tab
	Then I expect to be at page with title Omada | Processing of Personal Data
	And I expect to be at page with h1 header WEBSITE PRIVACY POLICY
	And I expect to be at page with text info@omada.net

@Desktop
Scenario: 13. Open Privacy Policy in another tab. Check if it is opened and loaded properly
	Given User at contact page
	And Privacy Policy at the bottom cookiebar opened in new tab
	And User at the first tab
	When Click on the element close cookies button
	And Close second tab
	And User switch to the first tab
	And Click on the element logo at the top
	Then I expect that element close cookies button is not displayed

@Desktop
Scenario Outline: 14. From the bottom of the Home page choose Cases link. On new open clickDownload PDF button. Fill necessary data to download PDF file.
	Given User at home page 
	And Click on the element close cookies button
	And Navigate to and click on the element Cases button at the footer
	When Navigate to and click in Omada Customers number number <number> on the Download PDF
	And Fill cases form field jobtitle with text Test Job Title
	And Fill cases form field firstname with text Test First Name
	And Fill cases form field lastname with text Test Last Name
	And Fill cases form field emailaddress1 with text andriistepura+omada-test14@gmail.com
	And Fill cases form field telephone1 with text +48 889 417 715
	And Fill cases form field parentcustomerid with text W2BUSINESS Sp. z O.o
	And Select cases form selector address1_county option Poland
	And Check checkbox newsletter accept checkbox
	And Unlock slider captcha if exists for 100%
	And Click on the element unlocked Download PDF button
	Then I expect to be at page with download-case part in url
	And I expect to be at page with h1 header Thank You for Your Request
	And I expect to be at page with text Download Customer Case:
	When Click on the element Download Customer Case link
	And File with name .pdf downloaded to you local machine
Examples:
| number |
| 1      |
| 2      |
| 3      |
| 4      |
| 5      |
| 6      |
| 7      |
| 8      |
| 9      |
| 10     |
| 11     |
| 12     |
| 13     |
| 14     |
| 15     |
| 16     |