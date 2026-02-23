using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TermikaSelenium4.Pages
{
    public class OlimpoksBasePO
    {
        private IWebElement _laborProtectionMenuItem => Driver.FindElement(By.XPath("//div[@class='menu-top_tab-link-header' and contains(text(),'Охрана труда')]"));
        private IWebElement _solutionsMenu => Driver.FindElement(By.XPath("//a[@class='menu-top_list-el-link' and contains(.,'Решения')]"));
        public IWebDriver Driver;
        private By _telegramPopupBody = By.XPath("//*[@id='modal-content-wrapper']");

        private const int waitTime = 7;
        private IWebElement _closeModal => Driver.FindElement(By.XPath("//*[@id='modal-close']"));
        WebDriverWait wait;
        public OlimpoksBasePO(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(Driver, System.TimeSpan.FromMilliseconds(3000));
        }

        public void ClickLaborProtectionMenuItem() {
            _laborProtectionMenuItem.Click();
        }

        public void ClickSolutionsMenuElement()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(_solutionsMenu));
            _solutionsMenu.Click();
        }
        public void HandleTelegramPopup()
        {
            try
            {
                // 2. Ждем, пока элемент станет кликабельным                
                wait.Until(ExpectedConditions.ElementToBeClickable(_closeModal));
                _closeModal.Click();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_telegramPopupBody));
                Console.WriteLine("Попап о подписке на Телеграм появился и закрыт.");
            }
            catch (WebDriverTimeoutException)
            {
                // 3. Если элемент не появился, просто продолжаем работу
                Console.WriteLine("Попап о подписке на Телеграм не появился, продолжаем работу.");
            }

        }

    }
}
