using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;
namespace SpecFlowHooks
{
    [Binding]
    public sealed class Hooks
    {
        public IWebDriver Driver;

        public Hooks(IWebDriver driver)
        {
            Driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}