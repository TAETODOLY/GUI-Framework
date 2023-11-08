using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        private readonly By _firstNameTextBoxLocator = By.XPath("//form[@id = '']");

        private IWebElement FirstNameTextBox => _driver.FindElement(_firstNameTextBoxLocator);
    }
}
