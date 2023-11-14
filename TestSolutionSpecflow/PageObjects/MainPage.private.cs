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
        public bool elementIsDisplayed(By locator)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(locator, _driverFactory.Configuration.LongWait);
                return _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickButton(By locator)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeClickable(locator, _driverFactory.Configuration.LongWait);
                _driver.FindElement(locator).Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the button. {e.Message}.", e.InnerException);
            }
        }

        public void AddNewProject(string projectName)
        {
            if (string.IsNullOrEmpty(projectName))
                throw new ArgumentException($"'{nameof(projectName)}' cannot be null or empty.", nameof(projectName));

            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_addNewProjectTextBox, _driverFactory.Configuration.LongWait);
                AddNewProjectTextBox.SendKeys(projectName);

                _driverFactory.WaitFluentlyForElementToBeClickable(_addNewProjectButton, _driverFactory.Configuration.LongWait);
                AddNewProjectButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Invalid project name. {e.Message}.", e.InnerException);
            }
        }
    }
}
