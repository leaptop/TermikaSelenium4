using OpenQA.Selenium.Chrome;

namespace TermikaSelenium4
{
    public class BasePO
    {
        public ChromeDriver Driver;
        public BasePO(ChromeDriver driver)
        {
            Driver = driver;
        }
    }
}
