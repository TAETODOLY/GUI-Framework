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
                ClickButton("LogOutButton","Main Page");
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Log Out Button. {e.Message}.", e.InnerException);
            }
        }
        /*private bool LogOutButtonDisplayed()
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
        } */
        public void ClickAddNewProject()
        {
            try
            {
                ClickButton("AddNewProjectButton","Main Page");
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
                WriteInput("NewProjectTextbox", "Main Page", projectName);
                
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
                ClickButton("AddNewProjectFinalButton", "Main Page");
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Add Project Button. {e.Message}.", e.InnerException);
            }
        }
        /*private bool ProjectCreated(string projectName)
        {
            try
            {
                ProjectCreated("NewProjectBox", "Main Page");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }*/
        private void WriteItemName(string itemName)
        {
            try
            {
                WriteInput("NewItemBox", "Main Page", itemName);
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
                ClickButton("AddNewItemButton", "Main Page");
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Add Item Button. {e.Message}.", e.InnerException);
            }
        }
        /*private bool ItemCreated(string itemName)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_newItem, _driverFactory.Configuration.LongWait);
                return NewItem.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }*/
        private void ClickProject(string projectName)
        {
            try
            {
                ClickButton("ProjectBox", "Main Page", projectName);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Add Item Button. {e.Message}.", e.InnerException);
            }
        }
    }
}
