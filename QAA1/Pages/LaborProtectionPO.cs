using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TermikaSelenium4.Pages
{
    public class LaborProtectionPO : OlimpoksBasePO
    {
        private IWebElement _workersChecbox => Driver.FindElement(By.XPath("//label[contains(text(),'Рабочие')]/input[@type='checkbox']"));
        private IWebElement _briefingLearningCheckBox => Driver.FindElement(By.XPath("//label[contains(text(),'Инструктаж')]/input[@type='checkbox']"));
        public LaborProtectionPO(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public void ClickWorkersCheckBox() { _workersChecbox.Click(); }
        public void ClickBriefingLearningCheckBox() { _briefingLearningCheckBox.Click(); }


    }
}
