using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace selenium_parallel_test_xunit
{
    public enum BrowserType
    {
        Chrome,
        Firefox
    }

    public class Hooks : Base, IDisposable
    {
        private BrowserType _browserType;
        public Hooks(BrowserType browser)
        {
            _browserType = browser;
            ChooseDriverInstance();
        }

        private void ChooseDriverInstance()
        {
            if (_browserType.Equals(BrowserType.Chrome))
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                Driver = new ChromeDriver();
            }
            else
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                Driver = new FirefoxDriver();
            }
        }



        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
