using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace HomeTask.Steps
{
    using System.Drawing;
    using NUnit.Framework;
    using OpenQA.Selenium;

    [Binding]
    public sealed class CheckContactFormSteps
    {
        private IWebDriver driver;
        public CheckContactFormSteps()
        {
            driver = (IWebDriver) ScenarioContext.Current["driver"];
        }

        [Given(@"Not logged in user")]
        public void GivenNotLoggedInUser()
        {
        }

        [Given(@"User at (.*) page")]
        public void GivenIMAtHomePage(string providedUrl)
        {
            string url = null;
            if (providedUrl == "home")
            {
                providedUrl = Data.Positive.homePageWithS;
                driver.Navigate().GoToUrl(providedUrl);
            }
            else driver.Navigate().GoToUrl(providedUrl);
            Assert.True(driver.Url == providedUrl, "Driver url is " + driver.Url + " when expected is " + providedUrl);
        }



        [When(@"I search for (.*)")]
        public void GivenISearchForGartner(string name)
        {
            var searchBox = driver.FindElement(By.XPath("//form[@class='header__search']/input[@name='q']"));
            searchBox.SendKeys(name);
            searchBox.SendKeys(Keys.Enter);
        }

        [When(@"Click on the link with text (.*)")]
        public void ThenClickOnTheLinkWithTextGartner(string texTlinKForClick)
        {
            var link = driver.FindElements(By.XPath($"//a[contains(text(), '{texTlinKForClick}')]"));
            Assert.That(link.Count, Is.EqualTo(1), "With entered text is not one link - " + link.Count + " when expected one");
            link[0].Click();
        }

        [When(@"I enter (.*) page")]
        public void WhenIEnterHomePage(string providedUrl)
        {
            string url = null;
            if (providedUrl == "home") driver.Navigate().GoToUrl(Data.Positive.homePage);
            else driver.Navigate().GoToUrl(providedUrl);
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
            var visible = driver.FindElements(By.Id("gbqfba"));
            
        }



    }
}
