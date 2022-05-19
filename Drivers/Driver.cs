using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace chrome_specflow.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public Driver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            chromeDriver.Manage().Window.Maximize();
            return chromeDriver;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            if (_currentWebDriverLazy.IsValueCreated)
            {
                //Current.Url = Configuration.LogoutURL;
                Current.Quit();
            }
            _isDisposed = true;

        }
    }
}
