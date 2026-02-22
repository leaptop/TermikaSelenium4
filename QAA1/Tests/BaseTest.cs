using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TermikaSelenium4.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver;
        public BaseTest()
        {

        }
        [SetUp]
        public void BeforeEach()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Dispose();
        }
    }
}
