using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Lesson1_IntroToSpecflow;

namespace Lesson1_SpecFlowAndSelenium.StepDefinitions
{
    [Binding]
    public class FirstTestSteps
    {
        private static IWebDriver _driver;

        public FirstTestSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I go to the ""(.*)"" website")]
        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        [When(@"I click on the Sign In button")]
        public void ClickSignIn()
        {
            IWebElement element = _driver.FindElement(By.CssSelector("#primary-menu > li.sign-in-link.hide-xs.hide-sm > a"));
            element.Click();
        }

        [Then(@"I should see the Sign In page")]
        public void SignIn()
        {
            Assert.AreEqual("https://www.browserstack.com/users/sign_in", _driver.Url);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            _driver.Quit();
        }
    }
}