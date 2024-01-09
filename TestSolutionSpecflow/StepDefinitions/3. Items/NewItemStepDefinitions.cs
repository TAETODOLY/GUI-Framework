using ConfigurationProvider.Classes;
using NUnit.Framework;
using OpenQA.Selenium;
using TestSolution.Models;
using TestSolution.PageObjects;
using WebDriverProvider.Classes;

namespace TestSolution.StepDefinitions
{
    [Binding]
    public class NewItemStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        public NewItemStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
            _mainPage = new MainPage(_factory);
        }

        [Given(@"The user creates a new item named ""([^""]*)""")]
        [When(@"The user creates a new item named ""([^""]*)""")]
        public void WhenTheUserCreatesANewItemNamed(string itemName)
        {
            var currentProject = _scenarioContext.Get<string>("Current Project");
            _mainPage.SelectProject(currentProject);

            _scenarioContext["ItemName"] = itemName;
            _mainPage.CreateNewItem(itemName);
        }

        [Then(@"The new item should be created")]
        public void ThenTheNewItemShouldBeCreated()
        {
            string itemName = _scenarioContext.Get<string>("ItemName");
            Assert.IsTrue(_mainPage.IsItemCreated(itemName));
        }
    }
}
