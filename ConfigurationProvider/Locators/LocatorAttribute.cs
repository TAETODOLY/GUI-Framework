using ConfigurationProvider.Enums;
using OpenQA.Selenium;

namespace ConfigurationProvider.Classes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class LocatorAttribute : Attribute
    {
        public LocatorType LocatorType { get; }
        public string Path { get; }

        public LocatorAttribute(LocatorType type, string path)
        {
            LocatorType = type;
            Path = path;
        }

        public By ToBy()
        {
            return LocatorType switch
            {
                LocatorType.XPath => By.XPath(Path),
                LocatorType.CssSelector => By.CssSelector(Path),
                LocatorType.Id => By.Id(Path),
                // other cases...
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}