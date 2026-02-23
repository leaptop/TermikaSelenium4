using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermikaSelenium4.Pages
{
    internal class CategoryPO : OlimpoksBasePO
    {
        public CategoryPO(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }
        private IWebElement _updatesButtonInModalWindow => Driver.FindElement(By.XPath(
            "//button[@id='updates-tab' and contains(text(),'Обновления')]"));
        /// <summary>
        /// Жмём кнопку "Обновления" в модальном окне, появляющемся после нажатия стрелочки вправо или кнопки "Подробнее" 
        /// на карточке инструктажа.
        /// </summary>
        public void ClickUpdatesButtonInModalWindow()
        {
            _updatesButtonInModalWindow.Click();
        }

        /// <summary>
        /// Получаем всю информацию в соответствии с заданием и записываем её в текстовый файл.
        /// </summary>      
        public void GetAllCardsInfoInTextFile()
        {
            string testDirectory = TestContext.CurrentContext.TestDirectory;
            string projectDirectory = Directory.GetParent(testDirectory).Parent.Parent.FullName;
            string outputDir = Path.Combine(projectDirectory, "Output");
            Directory.CreateDirectory(outputDir);
            string filePath = Path.Combine(outputDir, "courses_output.txt");
            File.WriteAllText(filePath, string.Empty);

            int totalCards = Driver.FindElements(By.CssSelector(".course-card")).Count;
            var cards = Driver.FindElements(By.XPath("//div[@class='course-card']"));
            for (int i = 0; i < totalCards; i++)
            {
                try
                {                   
                    var card = cards[i];

                    string code = card.FindElement(By.XPath(".//div[@class='course-card_code-number']")).Text.Trim();
                    string name = card.FindElement(By.XPath(".//div[@class='course-card_name']")).Text.Trim();

                    card.FindElement(By.CssSelector(".course-card_action-link")).Click();

                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                    wait.Until(ExpectedConditions.ElementToBeClickable(_updatesButtonInModalWindow));
                    ClickUpdatesButtonInModalWindow();

                    var updates = Driver.FindElements(By.XPath("//div[@class='course-update-card']"));

                    var closeButton = Driver.FindElement(By.XPath("//div[@id='course-detail']//button[@data-bs-dismiss='modal' or @class='btn-close']"));
                    closeButton.Click();
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("course-detail")));

                    string line = $"{name} ({code}) – {updates.Count()}";
                    File.AppendAllText(filePath, line + "\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в карточке {i}: {ex.Message}");
                }
            }
        }
    }
}
