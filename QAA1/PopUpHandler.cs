using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.DevTools.V129.Network;

namespace TermikaSelenium4
{
    internal class PopUpHandler
    {
        private const int waitTime = 7;
        public WebDriver WebDriver;
        private IWebElement _closeModal => WebDriver.FindElement(By.XPath("//*[@id='modal-close']"));
        public PopUpHandler(WebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public void HandleTelegramPopup()
        {
            try
            {
                // 2. Ждем, пока элемент станет кликабельным
                WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromMilliseconds(3000));
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
