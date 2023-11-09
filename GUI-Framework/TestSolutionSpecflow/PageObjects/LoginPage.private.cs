using WebDriverProvider.Extensions;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        private void ClickSignUp()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeClickable(_signUpButton, _driverFactory.Configuration.LongWait);
                SignUpButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Sign Up Button. {e.Message}.", e.InnerException);
            }
        }
        //private void ClearFirstNameTextBox()
        //{
        //    try
        //    {
        //        _driverFactory.WaitFluentlyForElementToBeVisible(_firstNameTextBoxLocator, _driverFactory.Configuration.LongWait);

        //        FirstNameTextBox.Clear();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Unable to clear the First Name textbox. {e.Message}.", e.InnerException);
        //    }
        //}

        //public void EnterFirstName(string firstName)
        //{
        //    try
        //    {
        //        ClearFirstNameTextBox();
        //        FirstNameTextBox.SendKeys(firstName);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Unable to enter '{nameof(firstName)}' into the First Name Textbox. {e.Message}", e.InnerException);
        //    }
        //}
    }
}
