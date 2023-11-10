using WebDriverProvider.Enums;

namespace WebDriverProvider.Interfaces;
public interface IWebDriverConfiguration
{
    string BaseUrl { get; set; }
    Browser Browser { get; set; }
    TimeSpan ImplicitWait { get; set; }
    TimeSpan LongWait { get; set; }
    TimeSpan MediumWait { get; set; }
    TimeSpan PageLoad { get; set; }
    TimeSpan ShortWait { get; set; }
    TimeSpan SleepInterval { get; set; }
}