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
    }
}
