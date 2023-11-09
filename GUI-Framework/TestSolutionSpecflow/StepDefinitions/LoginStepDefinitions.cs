using ConfigurationProvider.Classes;
using TestSolution.Models;
using TestSolution.PageObjects;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;

namespace TestSolution.StepDefinitions
{
    [Binding]
    public class LoginTests
    {
        private const string _newUserDataJson = "\\TestData\\NewUserData.json";

        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverFactory _factory;
        private readonly LoginPage _loginPage;

        public LoginTests(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _factory = (WebDriverFactory)_scenarioContext["DriverFactory"];
            _loginPage = new LoginPage(_factory);
        }

        [Given(@"I Register to the baseURL as ""([^""]*)""")]
        public void GivenIRegisterToTheBaseUrl(string configurationKey)
        {
            var configurationReader = new ConfigurationReader(AppContext.BaseDirectory + _newUserDataJson);
            var newUser = configurationReader.GetConfigurationSection<User>(configurationKey);

            _loginPage.RegisterUser(newUser);
        }

    }
}