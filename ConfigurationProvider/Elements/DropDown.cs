using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverProvider.Classes;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class DropDown : BaseWebElement
    {
        public DropDown(string name, Locator locator, WebDriverFactory driverFactory)
    : base(name, locator, driverFactory) { }

        public void SelectValue(string value)
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), _driverFactory.Configuration.LongWait);
            SelectElement select = new SelectElement(WebElement);
            IList<IWebElement> optionList = select.Options;
            select.SelectByValue(value);
        }
        public void SelectText(string text)
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), _driverFactory.Configuration.LongWait);
            SelectElement select = new SelectElement(WebElement);
            IList<IWebElement> optionList = select.Options;
            select.SelectByText(text);
        }
        public void SelectByTextContaining(string text)
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), _driverFactory.Configuration.LongWait);
            SelectElement select = new SelectElement(WebElement);
            IList<IWebElement> optionList = select.Options;
            foreach (var option in optionList)
            {
                if (option.Text.Contains(text))
                {
                    option.Click();
                    break;
                }
            }
        }
    }
}
