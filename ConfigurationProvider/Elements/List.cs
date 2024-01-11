using ConfigurationProvider.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverProvider.Classes;
using WebDriverProvider.Extensions;

namespace ConfigurationProvider.Classes.Elements
{
    public class List : BaseWebElement
    {
        public List(string name, Locator locator, WebDriverFactory driverFactory)
    : base(name, locator, driverFactory) { }

    }
}
