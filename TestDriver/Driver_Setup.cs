using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowUiAutomation
{
    [Binding]
    public class Driver_Setup
    {
        [Before]
        public void CreateWebDriver(ScenarioContext context)
        {
            IWebDriver webDriver = new ChromeDriver(Environment.CurrentDirectory);
            context["WEB_DRIVER"] = webDriver;
        }

        [After]
        public void CloseWebDriver(ScenarioContext context)
        {
            var driver = context["WEB_DRIVER"] as IWebDriver;
           driver.Quit();
        }
    }
}

