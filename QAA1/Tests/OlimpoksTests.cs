using NUnit.Framework;
using TermikaSelenium4.Pages;

namespace TermikaSelenium4.Tests
{
    public class OlimpoksTests : BaseTest
    {
        private OlimpoksBasePO _olimpoksBasePO;
        private LaborProtectionPO _laborProtectionPO;
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
            _laborProtectionPO = new LaborProtectionPO(Driver);
            _olimpoksBasePO.ClickSolutionsMenuElement();
            _olimpoksBasePO.ClickLaborProtectionMenuItem();
            _laborProtectionPO.ClickWorkersCheckBox();
            _laborProtectionPO.ClickBriefingLearningCheckBox();
            Thread.Sleep(700000);
        }

    }
}
