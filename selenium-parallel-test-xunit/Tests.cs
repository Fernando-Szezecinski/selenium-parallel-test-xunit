using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace selenium_parallel_test_xunit
{
    public class FirstTestCollection : Hooks
    {
        public FirstTestCollection() : base(BrowserType.Chrome)
        {

        }

        [Fact]
        public void TestUsingChromeDriver()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("selenium");
            Thread.Sleep(600);
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.True(Driver.PageSource.Contains("selenium"), "The text selenium doesn't exist");
        } 
    }

    public class SecondTestCollection : Hooks
    {
        public SecondTestCollection() : base(BrowserType.Firefox)
        {

        }

        [Fact]
        public void TestUsingFireFoxDriver()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("selenium");
            Thread.Sleep(600);
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.True(Driver.PageSource.Contains("selenium"), "The text selenium doesn't exist");
        }
    }
}
