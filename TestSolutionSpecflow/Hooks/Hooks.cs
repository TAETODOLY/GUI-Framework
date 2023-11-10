using Allure.Net.Commons;
using ConfigurationProvider.Classes;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;

namespace TestSolution.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly string _webDriverConfigurationJson;
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        public Hooks()
        {
            if (Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true")
            {
                _webDriverConfigurationJson = "Configurations//RemoteChromeDriverConfiguration.json";
            }
            else
            {
                _webDriverConfigurationJson = "Configurations//ChromeDriverConfiguration.json";
            }
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            var configurationReader = new ConfigurationReader(AppContext.BaseDirectory + _webDriverConfigurationJson);
            var configuration = configurationReader.GetConfiguration<WebDriverConfiguration>();
            var factory = new WebDriverFactory(configuration);
            factory.NavigateToBaseUrl();

            scenarioContext["DriverFactory"] = factory;
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            var factory = (WebDriverFactory)scenarioContext["DriverFactory"];

            if (factory is not null)
            {
                var driver = factory.GetInstanceOf();

                if (driver is not null)
                {
                    factory.TerminateWebDriver();
                }
            }
        }

    }
}
