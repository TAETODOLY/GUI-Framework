using ConfigurationProvider.Classes;
using NUnit.Framework;
using WebDriverProvider.Classes;
using WebDriverProvider.Configurations;

namespace TestSolution
{
    public class Tests
    {
        private WebDriverFactory _webDriverFactory;
        private ConfigurationReader _configurationReader;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Configurations\\ChromeDriverConfiguration.json")]
        public void Test1(string filePath)
        {
            _configurationReader = new ConfigurationReader(AppContext.BaseDirectory + filePath);
            var configuration = _configurationReader.GetConfiguration<WebDriverConfiguration>();

            _webDriverFactory = new WebDriverFactory(configuration);
            _webDriverFactory.NavigateToUrl();
            _webDriverFactory.TerminateWebDriver();
        }
    }
}