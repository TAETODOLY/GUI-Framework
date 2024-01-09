using OpenQA.Selenium;
using TestSolution.Models;
using WebDriverProvider.Extensions;

namespace TestSolution.PageObjects
{
    public partial class MainPage
    {
        private void ClickLogOut()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeClickable(_logOutButton, _driverFactory.Configuration.LongWait);
                LogOutButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Log Out Button. {e.Message}.", e.InnerException);
            }
        }
        private bool LogOutButtonDisplayed()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_logOutButton, _driverFactory.Configuration.LongWait);
                return LogOutButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void ClickAddNewProject()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_addNewProjectButton, _driverFactory.Configuration.LongWait);
                AddNewProjectButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Log Out Button. {e.Message}.", e.InnerException);
            }
        }
        private void WriteProjectName(string projectName)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_newProjectTextbox, _driverFactory.Configuration.LongWait);
                NewProjectTextbox.SendKeys(projectName);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to write the prject name. {e.Message}.", e.InnerException);
            }
        }
        private void ClickAddProject()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_addNewProjectFinalButton, _driverFactory.Configuration.LongWait);
                AddNewProjectFinalButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Add Project Button. {e.Message}.", e.InnerException);
            }
        }
        private bool ProjectCreated(string projectName)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_newProjectBox, _driverFactory.Configuration.LongWait);
                return NewProjectBox.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        private void WriteItemName(string itemName)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_newItemBox, _driverFactory.Configuration.LongWait);
                NewItemBox.SendKeys(itemName);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to write the item name. {e.Message}.", e.InnerException);
            }
        }
        private void ClickAddItem()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_addNewItemFinalButton, _driverFactory.Configuration.LongWait);
                AddNewItemButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Add Item Button. {e.Message}.", e.InnerException);
            }
        }
        private bool ItemCreated(string itemName)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_newItemBox, _driverFactory.Configuration.LongWait);
                return NewItemBox.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
