using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using System.IO;
using System.Drawing;


namespace HomeTask.Steps
{
    using System.Drawing;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    [Binding]
    public sealed class CheckContactFormSteps
    {


        private IWebDriver driver;
        public CheckContactFormSteps()
        {
            driver = (IWebDriver) ScenarioContext.Current["driver"];
        }

        [Given(@"User maximized browser window size")]
        public void GivenUserMaximizedBrowserWindowSize()
        {
            driver.Manage().Window.Maximize();
        }

        [Given(@"User use mobile browser window size")]
        public void GivenUserUseMobileBrowserWindowSize()
        {
            driver.Manage().Window.Size = new Size(240, 320);
        }

        [Given(@"User use browser window with (.*)px X (.*)px size")]
        public void GivenUserUseBrowserWindowSize(int w, int h)
        {
            driver.Manage().Window.Size = new Size(w, h);
        }

        [Given(@"Not logged in user")]
        public void GivenNotLoggedInUser()
        {
        }

        [Given(@"User at (.*) page")]
        public void GivenIMAtHomePage(string providedUrl)
        {
            if (providedUrl == "home")
            {
                providedUrl = Data.Positive.homePageWithS;
                driver.Navigate().GoToUrl(providedUrl);
            }
            else driver.Navigate().GoToUrl(providedUrl);
            Assert.True(driver.Url == providedUrl, "Driver url is " + driver.Url + " when expected is " + providedUrl);

            if (ConfigurationSettings.AppSettings["ClosedAllCookies"] == "true")
            { 
                if (driver.FindElement(By.XPath(Helpers.ElementPaths.GetElementPath("close cookies button"))).Displayed)
                {
                    driver.FindElement(By.XPath(Helpers.ElementPaths.GetElementPath("close cookies button"))).Click();
                }
            }
        }

        [Given(@"Taking screenshot of the entire screen saved with name (.*)")]
        public void GivenMakeScreenshot(string fileName)
        {
            TakeScreenshot.Main(driver, fileName);
        }

        [Then(@"Taking screenshot of the entire screen saved with name (.*)")]
        public void ThenMakeScreenshot(string fileName)
        {
            TakeScreenshot.Main(driver, fileName);
        }

        [When(@"I search for (.*)")]
        public void GivenISearchForGartner(string name)
        {
            var searchBox = driver.FindElement(By.XPath("//form[@class='header__search']/input[@name='q']"));
            searchBox.SendKeys(name);
            searchBox.SendKeys(Keys.Enter);
        }

        [When(@"Click on the link with text (.*)")]
        public void ThenClickOnTheLinkWithText(string texTlinKForClick)
        {
            var link = driver.FindElements(By.XPath($"//a[contains(text(), '{texTlinKForClick}')]"));
            Assert.That(link.Count, Is.EqualTo(1), "With entered text is not one link - " + link.Count + " when expected one");
            link[0].Click();
        }

        [When(@"Click in (.*) block on the (.*)")]
        public void ThenClickOnSetBlockLinkWithText(string blockType, string textLinkForClick)
        {
            var pathToLink = "";
            if (blockType == "breadcrumps") {pathToLink = "//main//";}
            if (blockType == "contacts for desktop") {pathToLink = "//div[@class='tabmenu__menu']/"; }
            
            var link = driver.FindElements(By.XPath($"{pathToLink}*[text()='{textLinkForClick}']"));
            Assert.That(link.Count, Is.EqualTo(1), "With entered block " + pathToLink + " and text " + textLinkForClick + " is more than just one link - " + link.Count);
            link[0].Click();
        }
        
        [When(@"I enter (.*) page")]
        public void WhenIEnterHomePage(string providedUrl = null)
        {
            if (providedUrl == "home") driver.Navigate().GoToUrl(Data.Positive.homePage);
            else driver.Navigate().GoToUrl(providedUrl);
        }

        [Given(@"Click on the element (.*)")]
        public void GivenNawigateToTheElement(string elementName)
        {
            WhenNawigateToTheElement(elementName);
        }

        [When(@"Click on the element (.*)")]
        public void WhenNawigateToTheElement(string elementName)
        {
            var pathToElement = Helpers.ElementPaths.GetElementPath(elementName); ;
            var element = driver.FindElement(By.XPath($"{pathToElement}"));

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(driver => element.Displayed);

            element.Click();
        }

        [When(@"Navigate to the element (.*)")]
        public void WhenMoveAndClickOnTheElement(string elementName)
        {
            var pathToElement = Helpers.ElementPaths.GetElementPath(elementName); ;
            var element = driver.FindElement(By.XPath($"{pathToElement}"));
            Actions action = new Actions(driver);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(driver => element.Displayed);

            action.MoveToElement(element).Perform();
        }
        
        [Then(@"I expect to see more than (.*) search results")]
        public void ThenIExpectToSeeMoreThanResult(int expectedSearchResultsCounter)
        {
            var searchResults = driver.FindElements(By.XPath("//div[@class='search-results__content']/section"));
            Assert.That(searchResults.Count, Is.AtLeast(expectedSearchResultsCounter), "Search results count is " + searchResults.Count + " when expected is more than " + expectedSearchResultsCounter);
        }

        [Then(@"I expect to see (.*) title in these search results")]
        public void ThenIExpectToSeeNameInThereSearchResults(string expectedSearchResultTitle)
        {
            var searchResults = driver.FindElements(By.XPath($"//div[@class='search-results__content']/section/a[contains(text(), '{expectedSearchResultTitle}')]"));
            Assert.That(searchResults.Count, Is.AtLeast(1), "Search results count is " + searchResults.Count + " when expected at least one result with title " + expectedSearchResultTitle);
        }

       [Then(@"I expect to be redirected to page (.*) with title (.*)")]
        public void ThenIExpectToBeRedirectedToPageWithTitle(string finalUrl, string pageTitle)
        {
            Assert.That(driver.Url, Is.EqualTo(finalUrl), "Driver url is " + driver.Url + " when expected is " + finalUrl);
            Assert.That(driver.Title, Is.EqualTo(pageTitle), "Driver title is " + driver.Title + " when expected is " + pageTitle);
        }

        [Then(@"I expect to be at page with (.*) part in url")]
        public void ThenIExpectToBeRedirectedToPageWithStringAsUrlPart(string expectedUrlPart)
        {
            Assert.True(driver.Url.Contains(expectedUrlPart), "Driver url is " + driver.Url + " not contains expected part " + expectedUrlPart);

        }

        [Then(@"I expect to be at page with header type (.*) contains string (.*) at least (.*) times")]
        public void ThenIExpectToBeRedirectedToPageWithHeaderTypeAndText(string headerType, string headerText, int headersCount)
        {
            var header = driver.FindElements(By.XPath($"//{headerType}[contains(text(), '{headerText}')]"));
            Assert.That(header.Count, Is.AtLeast(headersCount), "Header of type" + headerType + " with text " + headerText + " found at page " + header.Count + " times, when expected "+ headersCount);
        }

        [Then(@"I expect that (.*) is displayed")]
        public void ThenIExpectThatElementIsDisplayed(string expectedElement)
        {
            var element = driver.FindElements(By.Id("gbqfba"));
            
        }



    }
}
