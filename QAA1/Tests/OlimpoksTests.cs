using NUnit.Framework;
using TermikaSelenium4.Pages;

namespace TermikaSelenium4.Tests
{
    public class OlimpoksTests : BaseTest
    {
        private OlimpoksBasePO _olimpoksBasePO;
        private CoursesCatalogPO _coursesCatalogPO;
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("https://olimpoks.ru/");
            Driver.Manage().Window.Maximize();
            _olimpoksBasePO = new OlimpoksBasePO(Driver);
            _olimpoksBasePO.HandleTelegramPopup();
        }

        [Test]

        public void TestSolutionsClicking()
        {
            _coursesCatalogPO = new CoursesCatalogPO(Driver);
            _olimpoksBasePO.ClickSolutionsMenuElement();
            _olimpoksBasePO.ClickLaborProtectionMenuItem();
            _coursesCatalogPO.ClickWorkersCheckBox();
            _coursesCatalogPO.ClickBriefingLearningCheckBox();
            _coursesCatalogPO.FindAndExpandCoursesByCategory("Видеоинструктажи");
            Thread.Sleep(700000);
        }

    }
}
