using TestSolution.Models;
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
        private void ClickLogin()
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeClickable(_loginButton, _driverFactory.Configuration.LongWait);
                LoginButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to click the Log In Button. {e.Message}.", e.InnerException);
            }
        }
        private void LoginCredentials(User user)
        {
            try
            {
                _driverFactory.WaitFluentlyForElementToBeVisible(_emailTextBox, _driverFactory.Configuration.LongWait);
                EmailTextBox.SendKeys(user.Email);

                _driverFactory.WaitFluentlyForElementToBeVisible(_passwordTextBox, _driverFactory.Configuration.LongWait);
                PasswordTextBox.SendKeys(user.Password);

                _driverFactory.WaitFluentlyForElementToBeClickable(_loginFinalButton, _driverFactory.Configuration.LongWait);
                LoginFinalButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to Log In with Given Credentials. {e.Message}.", e.InnerException);
            }
        }
    }
}
