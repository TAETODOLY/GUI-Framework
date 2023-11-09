using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        private readonly By _signUpButton = By.XPath("//img[@src='/Images/design/pagesignup.png']");
        private readonly By _loginButton = By.XPath("//img[@src='/Images/design/pagelogin.png']");
        private readonly By _emailTextBox = By.XPath("//input[@id='ctl00_MainContent_LoginControl1_TextBoxEmail']");
        private readonly By _passwordTextBox = By.XPath("//input[@id='ctl00_MainContent_LoginControl1_TextBoxPassword']");
        private readonly By _loginFinalButton = By.XPath("//input[@id='ctl00_MainContent_LoginControl1_ButtonLogin']");

        private IWebElement SignUpButton => _driver.FindElement(_signUpButton);
        private IWebElement LoginButton => _driver.FindElement(_loginButton);
        private IWebElement EmailTextBox => _driver.FindElement(_emailTextBox);
        private IWebElement PasswordTextBox => _driver.FindElement(_passwordTextBox);
        private IWebElement LoginFinalButton => _driver.FindElement(_loginFinalButton);
    }
}
