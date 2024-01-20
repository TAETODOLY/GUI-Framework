using ConfigurationProvider.Classes;
using NUnit.Framework;
using OpenQA.Selenium;
using TestSolution.Models;
using TestSolution.PageObjects;
using WebDriverProvider.Classes;

namespace TestSolution.StepDefinitions
{
    [Binding]
    public class ItemsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        public ItemsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
            _mainPage = new MainPage(_factory);
        }

        [Given(@"The user creates a new item named ""([^""]*)"" in the current project")]
        [When(@"The user creates a new item named ""([^""]*)"" in the current project")]
        public void WhenTheUserCreatesANewItemNamed(string itemName)
        {
            var currentProject = _scenarioContext.Get<string>("Current Project");
            _mainPage.SelectProject(currentProject);

            _scenarioContext["ItemName"] = itemName;
            _mainPage.CreateNewItem(itemName);

        }

        [Given(@"The user opens the Options Menu in the ""([^""]*)"" item")]
        public void GivenTheUserOpensTheOptionsMenuInTheItem(string current)
        {
            var currentProject = _scenarioContext.Get<string>("Current Project");
            _mainPage.SelectProject(currentProject);

            var currentItem = _scenarioContext.Get<string>("Current Item");
            _mainPage.SelectItem(currentItem);

            _mainPage.SelectItemOptionMenu(currentItem);

        }

        [When(@"The user select the ""([^""]*)"" option in the options menu")]
        public void WhenTheUserSelectTheOptionInTheOptionsMenu(string delete)
        {
            throw new PendingStepException();
        }

        [Then(@"The item should be deleted")]
        public void ThenTheItemShouldBeDeleted()
        {
            throw new PendingStepException();
        }

        [Then(@"The new item should be created")]
        public void ThenTheNewItemShouldBeCreated()
        {
            string itemName = _scenarioContext.Get<string>("ItemName");
            Assert.IsTrue(_mainPage.IsItemCreated(itemName));
        }


    }
}
