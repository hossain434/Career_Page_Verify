using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowUiAutomation
{
    [Binding]
    public class Test_Carrer_Section
    {
        private readonly IWebDriver webDriver;

        public Test_Carrer_Section(ScenarioContext scenarioContext)
        {
            webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I have navigated to the career page on labcorp")]
        public void GivenIHaveNavigatedToThePageOnCareerSection()
        {
            // Navigate to the website
            webDriver.Url = $"http://www.labcorp.com";
            // To Maximize browser window
            webDriver.Manage().Window.Maximize();
            // Wait statement
            Task.Delay(5000).Wait();
            //Javascript command to scroll at the bottom of the page
            IJavaScriptExecutor jsDriver = webDriver as IJavaScriptExecutor;
            jsDriver.ExecuteScript("window.scrollBy(0, document.body.scrollHeight)");
        }

        [Then(@"Find and click Careers link")]
        public void ThenFindandclickCareerslink()
        {
        webDriver.FindElement(By.XPath("//footer/div/div/div[2]/div/nav/ul/li[10]/a")).Click();
        Task.Delay(5000).Wait();
        // Selenium to handle 2nd tab of browser
        webDriver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
        webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
        Task.Delay(5000).Wait();

        webDriver.FindElement(By.XPath("//*[starts-with(@id,'search-keyword')]")).SendKeys("QA Test Automation Developer");
        webDriver.FindElement(By.XPath("//*[starts-with(@id,'search-location')]")).Clear();
        webDriver.FindElement(By.XPath("//*[starts-with(@id,'search-submit')]")).Click();

        Task.Delay(7000).Wait();
        //Javascript command to scroll down
        //IJavaScriptExecutor jsDriver = webDriver as IJavaScriptExecutor;
        //jsDriver.ExecuteScript("window.scrollBy(0,62.400001525878906)");
        // Job title
        IWebElement job_heading = webDriver.FindElement(By.XPath("//main[@id='content']/div[3]/section[2]/h1"));
        // Job ID
        IWebElement job_id = webDriver.FindElement(By.XPath("//main[@id='content']/div[3]/section[2]/div/span[2]"));
        // Location
        IWebElement job_location = webDriver.FindElement(By.XPath("//main[@id='content']/div[3]/section[2]/div/span"));
        // Very text contains in the JOb Description
        IWebElement right_Candidate_Check = webDriver.FindElement(By.XPath("//main[@id='content']/div[3]/section[2]/div[2]/div/p[4]/span"));
        IWebElement Prepare_testPlan_Check = webDriver.FindElement(By.XPath("//main[@id='content']/div[3]/section[2]/div[2]/div/ul[3]/li[2]"));
        IWebElement experience_Check = webDriver.FindElement(By.XPath("//main[@id='content']/div[3]/section[2]/div[2]/div[2]/span/div"));
        IWebElement selenium_text = webDriver.FindElement(By.XPath("//main[@id='content']/div[3]/section[2]/div[2]/div[2]/span/div/ul/li[5]/span"));

        String getText_job_heading = job_heading.Text;
        String getText_job_id = job_id.Text;
        String getText_job_location = job_location.Text;

        String getText_right_Candidate = right_Candidate_Check.Text;
        String getText_jPrepare_testPlan = Prepare_testPlan_Check.Text;
        String getText_experience = experience_Check.Text;
        String getText_selenium = selenium_text.Text;

        // xUnit Assertions
        Assert.Contains("Senior QA Test Automation Developer / Engineer", getText_job_heading);
        Assert.Contains("Job ID 20-85412", getText_job_id);
        Assert.Contains("Durham, North Carolina", getText_job_location);

        Assert.Contains("The right candidate for this role will participate in the test automation technology development and best practice models", getText_right_Candidate);
        Assert.Contains("Prepare test plans, budgets, and schedules", getText_jPrepare_testPlan);
        Assert.Contains("5+ years of experience in QA automation development and scripting", getText_experience);
        Assert.Contains("Selenium", getText_selenium);
        }

    }
}