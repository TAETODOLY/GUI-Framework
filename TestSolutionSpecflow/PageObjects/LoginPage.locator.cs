using ConfigurationProvider.Classes.Elements;
using ConfigurationProvider.Classes;
using ConfigurationProvider.Elements;
using ConfigurationProvider.Enums;
using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        [Element("SignUpButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//img[@src='/Images/design/pagesignup.png']")]
        public Button? SignUpButton { get; }

        [Element("LoginButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//img[@src='/Images/design/pagelogin.png']")]
        public Button? LoginButton { get; }

        [Element("EmailTextBox", ElementType.TextBox)]
        [Locator(LocatorType.XPath, "//input[@id='ctl00_MainContent_LoginControl1_TextBoxEmail']")]
        public TextBox? EmailTextBox { get; }

        [Element("PasswordTextBox", ElementType.TextBox)]
        [Locator(LocatorType.XPath, "//input[@id='ctl00_MainContent_LoginControl1_TextBoxPassword']")]
        public TextBox? PasswordTextBox { get; }

        [Element("LoginFinalButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//input[@id='ctl00_MainContent_LoginControl1_ButtonLogin']")]
        public Button? LoginFinalButton { get; }
    }
}
