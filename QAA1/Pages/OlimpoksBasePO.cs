using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TermikaSelenium4.Pages
{
    public class OlimpoksBasePO
    {
        private IWebElement _laborProtectionMenuItem => Driver.FindElement(By.XPath(
            "//div[@class='menu-top_tab-link-header' and contains(text(),'Охрана труда')]"));
        private IWebElement _solutionsMenu => Driver.FindElement(By.XPath(
            "//a[@class='menu-top_list-el-link' and contains(.,'Решения')]"));
        public IWebDriver Driver;
        private By _telegramPopupWrapper = By.XPath("//*[@id='modal-content-wrapper']");

        private const int waitTime = 7;
        private IWebElement _closeModal => Driver.FindElement(By.XPath("//*[@id='modal-close']"));
        public WebDriverWait wait;
        public OlimpoksBasePO(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
        }
        /// <summary>
        /// Выбираем "Охрана труда" из меню "Решения".
        /// </summary>
        public void ClickLaborProtectionMenuItem()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(
                "//div[contains(@class,'menu-top_tab-link-wrapper')]")));
            _laborProtectionMenuItem.Click();
        }
        /// <summary>
        /// Нажимаем пункт меню "Решения" верхнего тулбара. 
        /// 
        /// Здесь видимо баг в том, что не всегда выезжает меню после 
        /// нажатия на кнопку "Решения". 
        /// </summary>
        public void ClickSolutionsMenuElement()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(_solutionsMenu));
            _solutionsMenu.Click();
        }

        /// <summary>
        /// Надо закрыть попап с предложением о подписке на Телеграм. 
        /// Проблема 1 с его закрытием в том, что он может появляться не всегда. Поэтому использую try catch. 
        /// Проблема 2 - видимо дело в том, что попап движется по экрану и его не всегда поучается закрыть с 
        /// первого раза, поэтому сделал цикл for для повторных попыток закрытия. 
        /// </summary>
        public void HandleTelegramPopup()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(_closeModal));
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(_closeModal));
                        _closeModal.Click();
                        break;//Если дошли сюда и не словили ElementClickInterceptedException,
                              //значит клик дошёл и попап будет закрыт.
                    }
                    catch (ElementClickInterceptedException)
                    {

                    }
                }
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_telegramPopupWrapper));
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
