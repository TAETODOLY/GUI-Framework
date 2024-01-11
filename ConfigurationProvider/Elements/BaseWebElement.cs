using AngleSharp.Dom;
using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebDriverProvider.Classes;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class BaseWebElement
    {
        public readonly WebDriverFactory _driverFactory;
        private readonly IWebDriver _driver;
        public string Name { get; set; }
        public Locator Locator { get; set; }
        private IWebElement? _webElement;
        public BaseWebElement(string name, Locator locator, WebDriverFactory driverFactory)
        {
            Name = name;
            Locator = locator;
            _driverFactory = driverFactory;
            _driver = _driverFactory.GetInstanceOf();
        }
        public IWebElement WebElement
        {
            get
            {
                if (_webElement == null)
                {
                    _webElement = _driver.FindElement(ConvertLocatorToBy(Locator));
                }
                return _webElement;
            }
        }
        public By ConvertLocatorToBy(Locator locator)
        {
            return locator.Type switch
            {
                LocatorType.XPath => By.XPath(locator.Value),
                _ => throw new NotImplementedException()
            };
        }
        public List<IWebElement> FindElements()
        {
            return _driver.FindElements(ConvertLocatorToBy(Locator)).ToList();
        }
        public string GetValue()
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), _driverFactory.Configuration.LongWait);
            return WebElement.GetAttribute("value");
        }
    }
}
