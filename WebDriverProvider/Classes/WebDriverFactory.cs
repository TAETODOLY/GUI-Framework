using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverProvider.Enums;
using WebDriverProvider.Interfaces;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Remote;

namespace WebDriverProvider.Classes;
public class WebDriverFactory
{
    // Dynamic so we can have different BrowserOptions
    private dynamic? _options;

    // Interface so we can read the Driver Configuration File
    private readonly IWebDriverConfiguration _configuration;
    // Initialize the WebDriver
    private readonly IWebDriver _webDriver;

    //Expose configuration
    public IWebDriverConfiguration Configuration => _configuration;

    // Constructor to Initialize WebDriver based on the config file
    public WebDriverFactory(IWebDriverConfiguration configuration)
    {
        if (configuration is null)
            throw new ArgumentNullException(nameof(configuration));

        // Give the configuration file to our Global IWebDriverConfiguration
        _configuration = configuration;

        // Given the config file, initialize the correct browser
        _webDriver = InstantiateWebDriver();
        SetupTimeouts();

        _webDriver.Manage().Window.Maximize();
        _webDriver.Manage().Cookies.DeleteAllCookies();
    }

    private IWebDriver InstantiateWebDriver()
    {
        IWebDriver webDriver = _configuration.Browser switch
        {
            Browser.RemoteChrome => InstantiateRemoteChromeDriver(true, "http://your-selenium-grid-hub-address:4444/wd/hub"),
            Browser.Chrome => InstantiateChromeDriver(false),
            Browser.HeadlessChrome => InstantiateChromeDriver(true),
            Browser.Firefox => InstantiateFirefoxDriver(false),
            Browser.HeadlessFirefox => InstantiateFirefoxDriver(true),
            Browser.Edge => InstantiateEdgeDriver(false),
            Browser.HeadlessEdge => InstantiateEdgeDriver(true),
            _ => InstantiateChromeDriver(false),
        };
        return webDriver;
    }

    private IWebDriver InstantiateRemoteChromeDriver(bool isHeadless, string seleniumGridUrl)
    {
        var chromeOptions = new ChromeOptions();

        if (isHeadless)
        {
            chromeOptions.AddArgument("--headless");
        }
        var capabilities = chromeOptions.ToCapabilities();

        var webDriver = new RemoteWebDriver(new Uri(seleniumGridUrl), capabilities);

        return webDriver;
    }

    private IWebDriver InstantiateChromeDriver(bool isHeadless)
    {
        if (isHeadless)
        {
            SetupHeadlessChromeOptions();
        }
        else
        {
            SetupChromeOptions();
        }

        _ = new DriverManager().SetUpDriver(new ChromeConfig());

        var webDriver = new ChromeDriver(_options);

        return webDriver;
    }

    private IWebDriver InstantiateFirefoxDriver(bool isHeadless)
    {
        if (isHeadless)
        {
            SetupHeadlessFirefoxOptions();
        }
        else
        {
            SetupFirefoxOptions();
        }

        _ = new DriverManager().SetUpDriver(new FirefoxConfig());

        var webDriver = new FirefoxDriver(_options);

        return webDriver;
    }

    private IWebDriver InstantiateEdgeDriver(bool isHeadless)
    {
        if (isHeadless)
        {
            SetupHeadlessEdgeOptions();
        }
        else
        {
            SetupEdgeOptions();
        }

        _ = new DriverManager().SetUpDriver(new EdgeConfig());

        var webDriver = new EdgeDriver(_options);

        return webDriver;
    }

    private void SetupChromeOptions()
    {
        _options = new ChromeOptions();

        _options.AddArgument("--incognito");
    }

    private void SetupHeadlessChromeOptions()
    {
        _options = new ChromeOptions();

        _options.AddArgument("--incognito");
        _options.AddArgument("--headless");
    }

    private void SetupFirefoxOptions()
    {
        _options = new FirefoxOptions();

        _options.AddArgument("--incognito");
    }

    private void SetupHeadlessFirefoxOptions()
    {
        _options = new FirefoxOptions();

        _options.AddArgument("--incognito");
        _options.AddArgument("--headless");
    }

    private void SetupEdgeOptions()
    {
        _options = new EdgeOptions();

        _options.AddArgument("--incognito");
    }

    private void SetupHeadlessEdgeOptions()
    {
        _options = new EdgeOptions();

        _options.AddArgument("--incognito");
        _options.AddArgument("--headless");
    }

    // Seting the timeouts according to the config file
    private void SetupTimeouts()
    {
        _webDriver.Manage().Timeouts().PageLoad = _configuration.PageLoad;
        _webDriver.Manage().Timeouts().ImplicitWait = _configuration.ImplicitWait;
    }

    public IWebDriver GetInstanceOf()
    {
        return _webDriver;
    }

    // Creating methods for the driver
    public void NavigateToBaseUrl()
    {
        _webDriver.Navigate().GoToUrl(_configuration.BaseUrl);
    }

    public void NavigateToUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException($"'{nameof(url)}' cannot be null or whitespace.", nameof(url));

        _webDriver.Navigate().GoToUrl(url);
    }

    public string GetCurrentUrl()
    {
        var url = _webDriver.Url;

        return url;
    }

    public string GetCurrentTitle()
    {
        var title = _webDriver.Title;

        return title;
    }

    public void SwitchToFirstTab()
    {
        var firstTab = _webDriver.WindowHandles.First();

        _webDriver.SwitchTo().Window(firstTab);
    }

    public void SwitchToLastTab()
    {
        var lastTab = _webDriver.WindowHandles.Last();

        _webDriver.SwitchTo().Window(lastTab);
    }

    public void CloseTab()
    {
        _webDriver.Close();
    }

    public void TerminateWebDriver()
    {
        _webDriver.Close();
        _webDriver.Quit();
        _webDriver.Dispose();

    }
}
