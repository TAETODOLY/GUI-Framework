using ConfigurationProvider.Classes;
using NUnit.Framework;
using TestSolution.Models;
using TestSolution.PageObjects;
using WebDriverProvider.Classes;

namespace TestSolution.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
            _mainPage = new MainPage(_factory);
        }

        [Given(@"The user clicks on ""([^""]*)"" button in the left navigation bar")]
        public void GivenTheUserClicksOnButton(string buttonName)
        {
            _mainPage.ClickAddNewProject();
        }
    }
}