using WebDriverProvider.Extensions;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        private void ClearFirstNameTextBox()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_firstNameTextBoxLocator, _driverFactory.Configuration.LongWait);

                FirstNameTextBox.Clear();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to clear the First Name textbox. {e.Message}.", e.InnerException);
            }
        }

        public void EnterFirstName(string firstName)
        {
            try
            {
                ClearFirstNameTextBox();
                FirstNameTextBox.SendKeys(firstName);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to enter '{nameof(firstName)}' into the First Name Textbox. {e.Message}", e.InnerException);
            }
        }
    }
}
