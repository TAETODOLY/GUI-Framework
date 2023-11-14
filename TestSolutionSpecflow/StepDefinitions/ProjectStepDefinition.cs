using ConfigurationProvider.Classes;
using NUnit.Framework;
using OpenQA.Selenium;
using TestSolution.Models;
using TestSolution.PageObjects;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;

namespace TestSolution.StepDefinitions
{
    [Binding]
    public class ProjectTest
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        public ProjectTest(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
            _mainPage = new MainPage(_factory);
        }

        [When(@"the user creates a new project called ""([^""]*)""")]
        public void WhenTheUserCreatesANewProjectCalled(string projectName)
        {
            _scenarioContext["ProjectName"] = projectName;
            _mainPage.AddNewProject(projectName);
        }

        [Then(@"a New Project should be created")]
        public void ThenANewProjectShouldBeCreated()
        {
            string projectName = _scenarioContext.Get<string>("ProjectName");
            By buttonSelector = By.XPath($"//td[@class='ProjItemContent' and text()='{projectName}']");
            Assert.IsTrue(_mainPage.elementIsDisplayed(buttonSelector)); 
        }

    }
}