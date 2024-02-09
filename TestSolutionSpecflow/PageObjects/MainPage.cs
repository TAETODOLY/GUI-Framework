using AngleSharp.Dom;
using ConfigurationProvider.Classes;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using TestSolution.Models;
using WebDriverProvider.Classes;

namespace TestSolution.PageObjects
{
    [View("Main Page")]

    public partial class MainPage : BasePageObject
    {

        public MainPage(WebDriverFactory driverFactory) : base(driverFactory) { }
        public bool IsDisplayedInMainPage(string elementName)
        {
            return IsDisplayed(elementName, "Main Page");
        }
        public void CreateNewProject(string projectName)
        {
            WriteProjectName(projectName);
            ClickAddProject();
        }
        public bool IsProjectCreated(string projectName)
        {
            return IsDisplayed("ProjectBox", "Main Page", projectName);
        }

        public void CreateNewItem(string itemName)
        {
            WriteItemName(itemName);
            ClickAddItem();
        }
        public bool IsItemCreated(string itemName)
        {
            return IsDisplayed("ItemBox", "Main Page", itemName);
        }
        public void SelectProject(string projectName)
        {
            ClickProject(projectName);
        }
        public void SelectOptionMenu(string itemName)
        {
            ClickOptionMenu(itemName);
        }
        public bool IsItemDisplayed(string itemName)
        {
            return IsDisplayed("ItemBox", "Main Page", itemName);
        }
        public bool IsItemDeleted(string itemName)
        {
            return IsDeleted("ItemBox", "Main Page", itemName);
        }
        public string GetColorForPriority(string settedPriority)
        {
            switch (settedPriority.ToLower())
            {
                case "1":
                    return "rgba(255, 51, 0, 1)"; // Red color
                case "2":
                    return "rgba(22, 139, 184, 1)"; // Blue color
                case "3":
                    return "rgba(81, 153, 45, 1)"; // Green color
                case "4":
                    return "rgba(0, 0, 0 ,1)"; // Black color
                default:
                    throw new ArgumentException($"Invalid priority: {settedPriority}");
            }
        }
        public string ItemPriority(string itemName)
        {
            return AttributeValue("ItemBox", "Main Page", itemName);
        }
    }
}
