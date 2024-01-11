using OpenQA.Selenium;
using TestSolution.Models;
using WebDriverProvider.Classes;

namespace TestSolution.PageObjects
{
    public partial class MainPage : BasePageObject
    {
        public MainPage(WebDriverFactory driverFactory) : base(driverFactory) { }
        public bool InMainPage()
        {
            return LogOutButtonDisplayed();
        }
        public void CreateNewProject(string projectName)
        {
            WriteProjectName(projectName);
            ClickAddProject();
        }
        public bool IsProjectCreated(string projectName)
        {
            return ProjectCreated(projectName);
        }

        public void CreateNewItem(string itemName)
        {
            WriteItemName(itemName);
            ClickAddItem();
        }
        public bool IsItemCreated(string itemName)
        {
            return ItemCreated(itemName);
        }
        public void SelectProject(string projectName)
        {
            ClickProject(projectName);
        }
    }
}
