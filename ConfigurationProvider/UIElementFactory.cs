using ConfigurationProvider.Classes.Elements;
using ConfigurationProvider.Elements;
using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using System.Linq.Expressions;
using System.Reflection;
using WebDriverProvider.Classes;

namespace ConfigurationProvider.Classes
{
    public static class UIElementFactory
    {
        private const string ViewsAssemblyName = "TestSolution";
        private const string ElementTypeClassName = "ConfigurationProvider.Classes.Elements.{0}";
        private const string UIElementsAssemblyName = "ConfigurationProvider";

        private static Type GetViewClassType(string viewName)
        {
            return Assembly.Load(ViewsAssemblyName).GetTypes()
                .FirstOrDefault(classType => classType.IsClass &&
                    classType.GetCustomAttribute<ViewAttribute>()?.Name == viewName)!;
        }
        public static dynamic GetPOElement(string elementName, string viewName, WebDriverFactory _driverFactory, params string[] locatorArguments)
        {
            var viewClassType = GetViewClassType(viewName);
            if (viewClassType == null)
            {
                throw new InvalidOperationException($"View class for {viewName} not found.");
            }

            var elementProperty = viewClassType.GetProperties()
                .FirstOrDefault(prop => prop.GetCustomAttribute<ElementAttribute>()?.Name == elementName);

            if (elementProperty == null)
            {
                throw new InvalidOperationException($"Element {elementName} not found in view {viewName}.");
            }

            ElementType elementType = elementProperty.GetCustomAttribute<ElementAttribute>()!.Type;
            string className = string.Format(ElementTypeClassName, elementType.ToString());
            Type elementClassType = Assembly.Load(UIElementsAssemblyName).GetType(className)!;

            var locator = GetLocator(elementProperty, locatorArguments);
            return Activator.CreateInstance(elementClassType, new object[] { elementName, locator, _driverFactory })!;
        }
        private static Locator GetLocator(PropertyInfo elementInfo, params string[] locatorArguments)
        {
            LocatorAttribute locatorAttr = elementInfo.GetCustomAttributes<LocatorAttribute>().FirstOrDefault()!;
            string locator = string.Format(locatorAttr.Path, locatorArguments);
            return new Locator(locatorAttr.LocatorType, locator);
        }
    }
}
