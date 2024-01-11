using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using System.Reflection;

namespace ConfigurationProvider.Classes
{
    public class LocatorHelper
    {
        public static By GetLocatorFromProperty(PropertyInfo propertyInfo)
        {
            var locatorAttribute = propertyInfo.GetCustomAttribute<LocatorAttribute>();
            if (locatorAttribute == null)
            {
                throw new InvalidOperationException("The Locator attribute is not found on the property");
            }

            return locatorAttribute.LocatorType switch
            {
                LocatorType.XPath => By.XPath(locatorAttribute.Path),
                LocatorType.CssSelector => By.CssSelector(locatorAttribute.Path),
                // handle other cases...
                _ => throw new InvalidOperationException("Unsupported locator type")
            };
        }
    }
}
