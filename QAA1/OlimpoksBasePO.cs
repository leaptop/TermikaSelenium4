using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TermikaSelenium4
{
    public class OlimpoksBasePO
    {
        private IWebElement _solutionsMenu => Driver.FindElement(By.XPath("//a[@class='menu-top_list-el-link' and contains(.,'Решения')]"));
        public ChromeDriver Driver;

        private const int waitTime = 7;
        private IWebElement _closeModal => Driver.FindElement(By.XPath("//*[@id='modal-close']"));
        public OlimpoksBasePO(ChromeDriver driver)
        {
            Driver = driver;
        }
       public void _clickSoltionsMenuElement()
        {
            _solutionsMenu.Click();
        }
        public void HandleTelegramPopup()
        {
            try
            {
                // 2. Ждем, пока элемент станет кликабельным
                WebDriverWait wait = new WebDriverWait(Driver, System.TimeSpan.FromMilliseconds(3000));
                wait.Until(ExpectedConditions.ElementToBeClickable(_closeModal));
                _closeModal.Click();
                Console.WriteLine("Попап о подписке на Телеграм не появился и закрыт.");
            }
            catch (WebDriverTimeoutException)
            {
                // 3. Если элемент не появился, просто продолжаем работу
                Console.WriteLine("Попап о подписке на Телеграм не появился, продолжаем работу.");
            }

        }

    }
}
