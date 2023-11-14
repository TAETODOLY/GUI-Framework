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
    public class CommonTest
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        public CommonTest(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
            _mainPage = new MainPage(_factory);
        }

        [Given(@"the user clicks on the ""([^""]*)"" button")]
        public void GivenTheUserClicksOnButton(string buttonText)
        {
            By buttonSelector = By.XPath($"//*[*='{buttonText}']");
            _mainPage.ClickButton(buttonSelector);
        }

        
    }
}