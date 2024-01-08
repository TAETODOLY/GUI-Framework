using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class MainPage
    {
        private readonly By _logOutButton = By.XPath("//a[@id='ctl00_HeaderTopControl1_LinkButtonLogout']");
        private readonly By _addNewProjectButton = By.XPath("//td[text()='Add New Project']");
        private readonly By _newProjectTextbox = By.XPath("//td[@class='ProjItemContent']//input[@id='NewProjNameInput']");
        private readonly By _addNewProjectFinalButton = By.XPath("//td[@class='ProjItemContent']//input[@id='NewProjNameButton']");
        private readonly By _newProjectBox = By.XPath("//td[@class='ProjItemContent' and text()='Errands']");

        private IWebElement LogOutButton => _driver.FindElement(_logOutButton);
        private IWebElement AddNewProjectButton => _driver.FindElement(_addNewProjectButton);
        private IWebElement NewProjectTextbox => _driver.FindElement(_newProjectTextbox);
        private IWebElement AddNewProjectFinalButton => _driver.FindElement(_addNewProjectFinalButton);
        private IWebElement NewProjectBox => _driver.FindElement(_newProjectBox);
    }
}
