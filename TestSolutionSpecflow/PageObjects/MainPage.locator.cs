using ConfigurationProvider.Classes;
using ConfigurationProvider.Classes.Elements;
using ConfigurationProvider.Elements;
using ConfigurationProvider.Enums;
using OpenQA.Selenium;

namespace TestSolution.PageObjects
{
    public partial class MainPage
    {
        [Element("LogOutButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//a[@id='ctl00_HeaderTopControl1_LinkButtonLogout']")]
        public Button? LogOutButton { get; }

        [Element("AddNewProjectButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//td[text()='Add New Project']")]
        public Button? AddNewProjectButton { get; }

        [Element("NewProjectTextbox", ElementType.TextBox)]
        [Locator(LocatorType.XPath, "//td[@class='ProjItemContent']//input[@id='NewProjNameInput']")]
        public TextBox? NewProjectTextbox { get; }

        [Element("AddNewProjectFinalButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//td[@class='ProjItemContent']//input[@id='NewProjNameButton']")]
        public Button? AddNewProjectFinalButton { get; }

        [Element("ProjectBox", ElementType.Button)]
        [Locator(LocatorType.XPath, "//td[@class='ProjItemContent' and text()='{0}']")]
        public Button? NewProjectBox { get; }

        [Element("NewItemBox", ElementType.TextBox)]
        [Locator(LocatorType.XPath, "//textarea[@class='InputTextAddItem InputTextAddItemWatermark']")]
        public TextBox? NewItemBox { get; }

        [Element("AddNewItemButton", ElementType.Button)]
        [Locator(LocatorType.XPath, "//input[@id='NewItemAddButton']")]
        public Button? AddNewItemButton { get; }

        [Element("ItemBox", ElementType.TextBox)]
        [Locator(LocatorType.XPath, "//div[@class='ItemContentDiv' and text()='{0}']")]
        public TextBox? ItemBox { get; }


    }
}
