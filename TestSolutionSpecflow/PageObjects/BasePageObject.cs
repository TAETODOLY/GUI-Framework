using ConfigurationProvider.Classes;
using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverProvider.Classes;

namespace TestSolution.PageObjects
{
    public abstract class BasePageObject
    {
        public WebDriverFactory _driverFactory;
        public readonly IWebDriver _driver;
        public BasePageObject(WebDriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
            _driver = _driverFactory.GetInstanceOf();
        }
        public void ClickButton(string elementName, string pageView, params string[] arguments)
        {
            try
            {
                var _button = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, arguments);
                _button.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the button. {e.Message}.", e.InnerException);
            }
        }
        public void WriteInput(string elementName, string pageView, string argument = "")
        {
            try
            {
                var _textBox = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _textBox.SendKeys(argument);

            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the button. {e.Message}.", e.InnerException);
            }
        }
        public string ElementValue(string elementName, string pageView, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                return _element.GetValue();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to retrieve the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }

        public void SelectElementByValue(string elementName, string pageView, string value, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _element.SelectValue(value);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to set the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }
        public void SelectElementByText(string elementName, string pageView, string value, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _element.SelectText(value);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to set the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }
        public void SelectElementByContainingText(string elementName, string pageView, string value, string argument = "")
        {
            try
            {
                var _element = UIElementFactory.GetPOElement(elementName, pageView, _driverFactory, argument);
                _element.SelectByTextContaining(value);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to set the value for {elementName}. {e.Message}.", e.InnerException);
            }
        }
    }
}
