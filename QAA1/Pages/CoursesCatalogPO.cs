using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TermikaSelenium4.Pages
{
    public class CoursesCatalogPO : OlimpoksBasePO
    {
        private IWebElement _workersChecbox => Driver.FindElement(By.XPath("//label[contains(text(),'Рабочие')]/input[@type='checkbox']"));
        private IWebElement _briefingLearningCheckBox => Driver.FindElement(By.XPath("//label[contains(text(),'Инструктаж')]/input[@type='checkbox']"));
        
        public CoursesCatalogPO(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }
        public void FindAndExpandCoursesByCategory(String category)
        {
            Driver.FindElement(By.XPath(GetXPathForButtonExpandingCategoriesCourses(category))).Click();

        }
        /// <summary>
        /// Сюда вводим назвние категории, для которой ищем икспас для кнопки 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private String GetXPathForButtonExpandingCategoriesCourses(String category)
        {
            return "//h2[@class='searchable-product' and contains(text(),'" + category
                + "')]/../following-sibling::div//div[@class='product-card_button-show-courses-text']";
        }
        /// <summary>
        /// Жмём кнопку "Подробнее" слева от кнопки с выпадающим списком, например "15 Курсов".
        /// </summary>
        /// <param name="category"></param>Вводим название категории, например "Видеоинструктажи" для поиска кнопки.
        public void ClickDetailsButtonByCategory(String category)
        {
            Driver.FindElement(By.XPath("//h2[@class='searchable-product' and contains(text(),'"
                +category+"')]/../..//a[contains(text(),'Подробнее')]")).Click();
        }

        public void ClickWorkersCheckBox() { _workersChecbox.Click(); }
        public void ClickBriefingLearningCheckBox() { _briefingLearningCheckBox.Click(); }


    }
}
