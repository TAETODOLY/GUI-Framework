using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationProvider.Classes
{
    public static class LocatorUtils
    {
        public static By ConvertToBy(LocatorAttribute locatorAttribute)
        {
            return locatorAttribute.LocatorType switch
            {
                LocatorType.XPath => By.XPath(locatorAttribute.Path),
                LocatorType.CssSelector => By.CssSelector(locatorAttribute.Path),
                //Locator.Id => By.Id(locatorAttribute.Path),
                // handle other cases...
                _ => throw new ArgumentOutOfRangeException($"Unsupported locator type: {locatorAttribute.LocatorType}")
            };
        }
    }
}
