using System;
using TechTalk.SpecFlow;
using SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Lesson1_IntroToSpecflow;

namespace Lesson1_SpecFlowAndSelenium.StepDefinitions
{
    [Binding]   
    public class BasicSeleniumTestSteps
    {
        private static IWebDriver _driver;
        private static readonly string username = "gary.b+demo@browserstack.com";
        private static readonly string password = "";

        public BasicSeleniumTestSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to the ""(.*)"" website")]
        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        [When("I navigate to the Sign In page")]
        public void ClickSignIn()
        {
            IWebElement element = _driver.FindElement(By.CssSelector("#primary-menu > li.sign-in-link.hide-xs.hide-sm > a"));
            element.Click();
        }

        [When("I enter the correct username and password")]
        public void EnterCredentials()
        {
            IWebElement usernameElement = _driver.FindElement(By.CssSelector("#user_email_login"));
            usernameElement.SendKeys(username);

            IWebElement passwordElement = _driver.FindElement(By.CssSelector("#user_password"));
            passwordElement.SendKeys(password);

            IWebElement submitButtonElement = _driver.FindElement(By.CssSelector("#user_submit"));
            submitButtonElement.Click();
        }

        [Then(@"I have logged in successfully")]
        public void SignIn()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(c => c.FindElement(By.Id("beamer-bell")));
            Console.WriteLine("URL: " + _driver.Url);
            Assert.IsTrue(_driver.FindElement(By.Id("beamer-bell")).Displayed);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            _driver.Quit();
        }
    }
}
