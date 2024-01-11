using ConfigurationProvider.Enums;
using OpenQA.Selenium;

namespace ConfigurationProvider.Classes
{
    public class Locator
    {
        public LocatorType Type { get; set; }

        public string Value { get; set; }

        public Locator(LocatorType type, string value)
        {
            Type = type;
            Value = value;
        }

        public By GetBy()
        {
            switch (Type)
            {
                case LocatorType.XPath:
                    return By.XPath(Value);

                case LocatorType.Id:
                    return By.Id(Value);

                case LocatorType.CssSelector:
                    return By.CssSelector(Value);

                default:
                    throw new Exception($"Cannot get '{typeof(By)}' object for '{Type}'.");
            }
        }
    }
}
