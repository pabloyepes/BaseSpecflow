using System.Threading;
using OpenQA.Selenium;

namespace PageObject
{
    public class GoogleHomePage
    {
        private readonly IWebDriver _webDriver;

        public GoogleHomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            this.EnsureLoginIsOpenAndReset();
        }

        public void EnsureLoginIsOpenAndReset()
        {
            _webDriver.Url = "https://www.google.com";
        }

        private IWebElement SearchInput => _webDriver.FindElement(By.CssSelector("input[name=q]"));

        private IWebElement SearchButton => _webDriver.FindElement(By.Id("user_session_password"));

        private IWebElement LoginButton => _webDriver.FindElement(By.CssSelector("input[value=Login]"));

        public void Search(string search)
        {
            this.SearchInput.SendKeys(search);
            Thread.Sleep(10000);
        }
    }
}
