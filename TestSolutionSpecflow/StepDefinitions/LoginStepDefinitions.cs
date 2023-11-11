using ConfigurationProvider.Classes;
using NUnit.Framework;
using TestSolution.Models;
using TestSolution.PageObjects;
using WebDriverProvider.Classes;

namespace TestSolution.StepDefinitions
{
    [Binding]
    public class LoginTests
    {
        private const string _newUserDataJson = "//TestData//NewUserData.json";

        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;

        public LoginTests(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
            _mainPage = new MainPage(_factory);
        }

        [Given(@"the user logs in to the baseURL as ""([^""]*)""")]
        public void GivenILoginToTheBaseUrl(string configurationKey)
        {
            var configurationReader = new ConfigurationReader(AppContext.BaseDirectory + _newUserDataJson);
            var newUser = configurationReader.GetConfigurationSection<User>(configurationKey);
            
            _loginPage.LoginUser(newUser);
        }

        [Then(@"the user should be logged in")]
        public void ThenTheUserShouldBeOnPage()
        {
            Assert.IsTrue(_mainPage.InMainPage());
        }

    }
}