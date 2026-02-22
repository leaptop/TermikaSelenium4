using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace TermikaSelenium4
{
    public class BaseTest
    {
        public ChromeDriver Driver;
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
