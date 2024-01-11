using ConfigurationProvider.Classes;
using OpenQA.Selenium;
using TestSolution.Models;
using WebDriverProvider.Classes;

namespace TestSolution.PageObjects
{
    [View("Login Page")]
    public partial class LoginPage : BasePageObject
    {
        public LoginPage(WebDriverFactory driverFactory) : base(driverFactory) { }
        public void RegisterUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            //ClickSignUp();
        }
        public void LoginUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            LoginWithCredentials(user);
        }
    }
}
