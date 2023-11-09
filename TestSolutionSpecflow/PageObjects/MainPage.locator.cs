using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class MainPage
    {
        private readonly By _logOutButton = By.XPath("//a[@id='ctl00_HeaderTopControl1_LinkButtonLogout']");

        private IWebElement LogOutButton => _driver.FindElement(_logOutButton);
    }
}
