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
            Driver.FindElement(By.XPath("//h2[@class='searchable-product' and contains(text(),'" + category
                + "')]/../following-sibling::div//div[@class='product-card_button-show-courses-text']")).Click();

        }

        public void ClickWorkersCheckBox() { _workersChecbox.Click(); }
        public void ClickBriefingLearningCheckBox() { _briefingLearningCheckBox.Click(); }


    }
}
