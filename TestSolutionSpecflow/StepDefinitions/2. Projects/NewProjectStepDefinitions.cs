using ConfigurationProvider.Classes;
using NUnit.Framework;
using OpenQA.Selenium;
using TestSolution.Models;
using TestSolution.PageObjects;
using WebDriverProvider.Classes;

namespace TestSolution.StepDefinitions
{
    [Binding]
    public class ProjectTests
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        public ProjectTests(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
            _mainPage = new MainPage(_factory);
        }

        [When(@"The user creates a new project named ""([^""]*)""")]
        public void WhenTheUserCreatesANewProjectNamed(string projectName)
        {
            _scenarioContext["ProjectName"] = projectName;
            _mainPage.CreateNewProject(projectName);
        }

        [Then(@"The new project should be created")]
        public void ThenTheNewProjectShouldBeCreated()
        {
            string projectName = _scenarioContext.Get<string>("ProjectName");
            Assert.IsTrue(_mainPage.IsProjectCreated(projectName));
        }

    }
}