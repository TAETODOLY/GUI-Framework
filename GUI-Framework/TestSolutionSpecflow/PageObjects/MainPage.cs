using OpenQA.Selenium;
using TestSolution.Models;
using WebDriverProvider.Classes;

namespace TestSolution.PageObjects
{
    public partial class MainPage
    {
        private readonly WebDriverFactory _driverFactory;
        private readonly IWebDriver _driver;
        public MainPage(WebDriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
            _driver = _driverFactory.GetInstanceOf();
        }
        public bool InMainPage()
        {
            return LogOutButtonDisplayed();
        }
    }
}
