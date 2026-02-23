using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace TermikaSelenium4.Pages
{
    public class CoursesCatalogPO : OlimpoksBasePO
    {
        private IWebElement _workersChecbox => Driver.FindElement(By.XPath("//label[contains(text(),'Рабочие')]/input[@type='checkbox']"));
        private IWebElement _briefingLearningCheckBox => Driver.FindElement(By.XPath("//label[contains(text(),'Инструктаж')]/input[@type='checkbox']"));
        private IWebElement _searchField => Driver.FindElement(By.XPath("//input[@id='catalog-search-bar-input']"));
        private IWebElement _noCoursesMessage => Driver.FindElement(By.XPath("//div[contains(@class,'products-count') and text()='Нет курсов, соответствующих заданному фильтру']"));
        private IWebElement _searchButton => Driver.FindElement(By.XPath("//button[contains(@id,'catalog-search-bar-search-btn')]"));
        private IWebElement _labelCoursesCountedNumber => Driver.FindElement(By.XPath("//div[contains(@class,'products-count mt-30')]"));


        public CoursesCatalogPO(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }
        public int GetTheNumberOfCoursesLabel()
        {
            return int.Parse(Regex.Match(_labelCoursesCountedNumber.Text, @"\d+").Value); 
        }
        public int CountNumberOfCoursesFound()
        {
            return Driver.FindElements(By.XPath("//div[contains(@class,'product-card block-gray mt-40 show')]")).Count;
        }
        public void FindAndExpandCoursesByCategory(String category)
        {
            Driver.FindElement(By.XPath(GetXPathForButtonExpandingCategoriesCourses(category))).Click();
        }

        public void SearchCourse(String str)
        {
            _searchField.SendKeys(str);
            wait.Until(ExpectedConditions.ElementToBeClickable(_searchButton));
            _searchButton.Click();
            Thread.Sleep(1000);
            _searchButton.Click();//Почему-то с первого раза клик не доходит
        }

        public bool ConfirmNoCurrsesFoundMessageIsShown()
        {
            return _noCoursesMessage.Displayed;
        }
        //public Int32 countDisplayedCourses()
        //{
            
        //}
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
                + category + "')]/../..//a[contains(text(),'Подробнее')]")).Click();
        }

        public void ClickWorkersCheckBox() { _workersChecbox.Click(); }
        public void ClickBriefingLearningCheckBox() { _briefingLearningCheckBox.Click(); }
    }
}
