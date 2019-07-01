using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Newtonsoft.Json;

namespace GoogleSearch
{
    [Binding]
    public class GoogleSearchFeatureSteps
    {
        IWebDriver driver = new ChromeDriver();

        [Given(@"I have entered the Google Home Page")]
        public void GivenIHaveEnteredTheGoogleHomePage()
        {
            driver.Navigate().GoToUrl("https://www.google.pl");
            driver.Manage().Window.Maximize();
        }

        [Given(@"I see the page is loaded")]
        public void GivenISeeThePageIsLoaded()
        {
            Assert.AreEqual("Google", driver.Title);
        }

        [When(@"I have entered selenium webdriver in the Search Text box")]
        public void WhenIHaveEnteredSeleniumWebdriverInTheSearchTextBox()
        {
            driver.FindElement(By.Name("q")).SendKeys("selenium webdriver");
        }

        [When(@"I click on Search Button")]
        public void IClickOnSearchButton()
        {
            driver.FindElement(By.Name("btnK")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Then(@"The result should be a new page with results for selenium webdriver")]
        public void ThenTheResultShouldBeANewPageWithResultsForSeleniumWebdriver()
        {
            IReadOnlyCollection<IWebElement> linkResults = driver.FindElements(By.CssSelector(".iUh30"));
            IWebElement firstResult = linkResults.ElementAt(1);
      
            Assert.That(firstResult, Does.Contain("www.seleniumhq.org").IgnoreCase);
        }
    }
}
