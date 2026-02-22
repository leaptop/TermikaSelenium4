using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TermikaSelenium4
{
    public class OlimpoksPO : BasePO
    {
        private IWebElement _inputTextField;

        private IWebElement _clickCatalogButton => Driver.FindElement(By.XPath("//button[@aria-label='More source languages']"));

       
        public OlimpoksPO(ChromeDriver driver) : base(driver)
        {
            Driver = driver;
            driver.Navigate().GoToUrl("https://olimpoks.ru/");

        }

        public void ClickCatalogButton()
        {
            _clickCatalogButton.Click();
        }    

    }
}
