using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebDriverProvider.Classes;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class Button : BaseWebElement
    {
        public Button(string name, Locator locator, WebDriverFactory driverFactory)
    : base(name, locator, driverFactory) { }

        public void Click()
        {
            _driverFactory.WaitFluentlyForElementToBeClickable(ConvertLocatorToBy(Locator), _driverFactory.Configuration.LongWait);
            WebElement.Click();
        }
    }
}
