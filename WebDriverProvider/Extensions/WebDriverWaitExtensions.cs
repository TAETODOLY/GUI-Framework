using WebDriverProvider.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverProvider.Extensions
{
    public static class WebDriverFactoryWaitExtension
    {
        public static void WaitForElementToBeVisible(this WebDriverFactory factory, By locator, TimeSpan timeout)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (locator is null)
                throw new ArgumentNullException(nameof(locator));

            var webDriverWait = new WebDriverWait(factory.GetInstanceOf(), timeout);

            webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public static void WaitFluentlyForElementToBeVisible(this WebDriverFactory factory, By locator, TimeSpan timeout)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (locator is null)
                throw new ArgumentNullException(nameof(locator));

            var clock = new SystemClock();

            var webDriverWait = new WebDriverWait(clock, factory.GetInstanceOf(), timeout, factory.Configuration.SleepInterval);

            webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public static void WaitForElementToBeClickable(this WebDriverFactory factory, By locator, TimeSpan timeout)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (locator is null)
                throw new ArgumentNullException(nameof(locator));

            var webDriverWait = new WebDriverWait(factory.GetInstanceOf(), timeout);

            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public static void WaitFluentlyForElementToBeClickable(this WebDriverFactory factory, By locator, TimeSpan timeout)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (locator is null)
                throw new ArgumentNullException(nameof(locator));

            var clock = new SystemClock();

            var webDriverWait = new WebDriverWait(clock, factory.GetInstanceOf(), timeout, factory.Configuration.SleepInterval);

            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public static void WaitFluentlyForElementToDisappear(this WebDriverFactory factory, By locator, TimeSpan timeout)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (locator is null)
                throw new ArgumentNullException(nameof(locator));

            var clock = new SystemClock();

            var webDriverWait = new WebDriverWait(clock, factory.GetInstanceOf(), timeout, factory.Configuration.SleepInterval);

            webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        public static void WaitFluentlyForUrlToContain(this WebDriverFactory factory, string partialUrl, TimeSpan timeout)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));
            if (string.IsNullOrWhiteSpace(partialUrl))
                throw new ArgumentNullException(nameof(partialUrl));

            var clock = new SystemClock();

            var webDriverWait = new WebDriverWait(clock, factory.GetInstanceOf(), timeout, factory.Configuration.SleepInterval);

            webDriverWait.Until(ExpectedConditions.UrlContains(partialUrl));
        }


    }
}
