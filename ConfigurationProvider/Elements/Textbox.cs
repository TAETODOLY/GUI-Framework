using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverProvider.Classes;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class TextBox : BaseWebElement
    {
        public TextBox(string name, Locator locator, WebDriverFactory driverFactory)
    : base(name, locator, driverFactory) { }

        public void SendKeys(string keyToSend)
        {
            _driverFactory.WaitFluentlyForElementToBeVisible(ConvertLocatorToBy(Locator), _driverFactory.Configuration.LongWait);

            WebElement.Clear();
            WebElement.SendKeys(keyToSend);
            Thread.Sleep(1000);
            WebElement.SendKeys(Keys.Tab);
        }
    }
}
