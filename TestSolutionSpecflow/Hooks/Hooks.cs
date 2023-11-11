using Allure.Net.Commons;
using ConfigurationProvider.Classes;
using Helpers.Classes;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;
using RestSharp;
using TestSolution.Models;
using System.Text.Json;

namespace TestSolution.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public readonly RestHelper client;
        private readonly ScenarioContext _scenarioContext;
        private readonly string _webDriverConfigurationJson;
        public static AllureLifecycle allure = AllureLifecycle.Instance;
        private const string _newUserDataJson = "//Configurations//ResthelperConfigurations.json";

        public Hooks(ScenarioContext scenarioContext)
        {
            if (Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true")
            {
                _webDriverConfigurationJson = "Configurations//RemoteChromeDriverConfiguration.json";
            }
            else
            {
                _webDriverConfigurationJson = "Configurations//ChromeDriverConfiguration.json";
            }

            var configurationReader = new ConfigurationReader(AppContext.BaseDirectory + _newUserDataJson);
            var RestConfig = configurationReader.GetConfigurationSection<RestConfig>("adminuser");

            client = new RestHelper(RestConfig.Url, RestConfig.Email, RestConfig.Password);
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 1)]
        public void CreateProject()
        {
            var scenarioTags = _scenarioContext.ScenarioInfo.Tags.ToList();
            scenarioTags = scenarioTags
                .Where(tag => tag.StartsWith("create.project."))
                .Select(tag => tag.Replace("create.project.", ""))
                .ToList();

            if (scenarioTags.Count.Equals(0))
            {
                return;
            }

            foreach (string tag in scenarioTags)
            {
                CreateProject(tag);
            }
        }

        public void CreateProject(string tag)
        {
            string body = $"{{ \"Content\": \"{tag}\" }}";
            var response = client.DoRequest(Method.Post, "/projects.json", body);
            _scenarioContext["Current Project"] = response;
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
        [AfterTestRun]
        public static void CleanUp()
        {
            RemoveAllprojects();
        }

        public static void RemoveAllprojects()
        {
            var configurationReader = new ConfigurationReader(AppContext.BaseDirectory + _newUserDataJson);
            var RestConfig = configurationReader.GetConfigurationSection<RestConfig>("adminuser");

            var client = new RestHelper(RestConfig.Url, RestConfig.Email, RestConfig.Password);
            var responseGetProjects = client.DoRequest(Method.Get, "/projects.json", null);
            var projects = JsonSerializer.Deserialize<IEnumerable<ProjectModel>>(responseGetProjects.Content!);
        
            foreach(var project in projects!)
            {
                string url = $"projects/{project.Id}.json";
                var responseDelProjects = client.DoRequest(Method.Delete, url, null);
                if(!responseDelProjects.IsSuccessful)
                {
                    throw new Exception($"Unable to Delete the Projects.");
                }
            }
        }
    }
}
