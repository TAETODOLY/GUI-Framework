using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class MainPage
    {
        private readonly By _logOutButton = By.XPath("//a[@id='ctl00_HeaderTopControl1_LinkButtonLogout']");
        private readonly By _addNewProjectTextBox = By.XPath("//input[@id='NewProjNameInput']");
        private readonly By _addNewProjectButton = By.XPath("//input[@id='NewProjNameButton']");

        private IWebElement LogOutButton => _driver.FindElement(_logOutButton);
        private IWebElement AddNewProjectTextBox => _driver.FindElement(_addNewProjectTextBox);
        private IWebElement AddNewProjectButton => _driver.FindElement(_addNewProjectButton);

    }
}
