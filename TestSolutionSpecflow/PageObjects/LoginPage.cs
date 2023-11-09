using OpenQA.Selenium;
using TestSolution.Models;
using WebDriverProvider.Classes;

namespace TestSolution.PageObjects
{
    public partial class LoginPage
    {
        private readonly WebDriverFactory _driverFactory;
        private readonly IWebDriver _driver;
        public LoginPage(WebDriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
            _driver = _driverFactory.GetInstanceOf();
        }
        public void RegisterUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            ClickSignUp();
        }
        public void LoginUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            ClickLogin();
            LoginCredentials(user);
        }
    }
}
