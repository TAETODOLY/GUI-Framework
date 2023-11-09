using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        private readonly By _signUpButton = By.XPath("//img[@src='/Images/design/pagesignup.png']");

        private IWebElement SignUpButton => _driver.FindElement(_signUpButton);
    }
}
