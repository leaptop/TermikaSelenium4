using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TermikaSelenium4.Pages;

namespace TermikaSelenium4.Tests
{
    public class OlimpoksTests 
    {
        public IWebDriver Driver;
        private OlimpoksBasePO _olimpoksBasePO;
        private CoursesCatalogPO _coursesCatalogPO;
        private CategoryPO _categoryPO;
        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl("https://olimpoks.ru/");
            Driver.Manage().Window.Maximize();
            _olimpoksBasePO = new OlimpoksBasePO(Driver);
            _olimpoksBasePO.HandleTelegramPopup();
        }
        [TearDown]
        public void AfterEach()
        {
            Driver.Dispose();
        }
        [Test]
        public void TestShownCoursesAreCountedProperly()
        {
            _olimpoksBasePO.ClickSolutionsMenuElement();
            _olimpoksBasePO.ClickLaborProtectionMenuItem();
            _coursesCatalogPO = new CoursesCatalogPO(Driver);
            _coursesCatalogPO.SearchCourse("свароч");
            Assert.That(_coursesCatalogPO.CountNumberOfCoursesFound().Equals(_coursesCatalogPO.GetTheNumberOfCoursesLabel()),
               "Лейбл с числом найденных курсов слева сверху показывает неверное число");
        }
        [Test]
        public void TestNonExistentCourseSearchResult()
        {
            _olimpoksBasePO.ClickSolutionsMenuElement();
            _olimpoksBasePO.ClickLaborProtectionMenuItem();
            _coursesCatalogPO = new CoursesCatalogPO(Driver);
            _coursesCatalogPO.SearchCourse("Несуществующий493Курс");
            Assert.That(_coursesCatalogPO.ConfirmNoCurrsesFoundMessageIsShown, Is.True);
            Assert.That(_coursesCatalogPO.CountNumberOfCoursesFound().Equals(0));
        }

        [Test]
        public void TestTextSavingTask1()
        {
            _olimpoksBasePO.ClickSolutionsMenuElement();
            _olimpoksBasePO.ClickLaborProtectionMenuItem();
            _coursesCatalogPO = new CoursesCatalogPO(Driver);
            _coursesCatalogPO.ClickWorkersCheckBox();
            _coursesCatalogPO.ClickBriefingLearningCheckBox();
            _coursesCatalogPO.ClickDetailsButtonByCategory("Видеоинструктажи");
            _categoryPO = new CategoryPO(Driver);
            _categoryPO.GetAllCardsInfoInTextFile();
        }
    }
}
