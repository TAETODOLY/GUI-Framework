using TestSolution.Models;
using WebDriverProvider.Extensions;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        //private void ClickSignUp()
        //{
        //    try
        //    {
        //        _driverFactory.WaitFluentlyForElementToBeClickable(_signUpButton, _driverFactory.Configuration.LongWait);
        //        SignUpButton.Click();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Unable to click the Sign Up Button. {e.Message}.", e.InnerException);
        //    }
        //}
        //private void ClickLogin()
        //{
        //    try
        //    {
        //        _driverFactory.WaitFluentlyForElementToBeClickable(_loginButton, _driverFactory.Configuration.LongWait);
        //        LoginButton.Click();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Unable to click the Log In Button. {e.Message}.", e.InnerException);
        //    }
        //}
        private void LoginWithCredentials(User user)
        {
            try
            {
                ClickButton("LoginButton", "Login Page");
                WriteInput("EmailTextBox", "Login Page", user.Email);
                WriteInput("PasswordTextBox", "Login Page", user.Password);
                ClickButton("LoginFinalButton", "Login Page");
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to Log In with Given Credentials. {e.Message}.", e.InnerException);
            }
        }
    }
}
