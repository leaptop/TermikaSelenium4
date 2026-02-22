using NUnit.Framework;
using TermikaSelenium4.Pages;

namespace TermikaSelenium4.Tests
{
    public class OlimpoksTests : BaseTest
    {
        private OlimpoksPO _olimpoksPO;
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("https://olimpoks.ru/");
            Driver.Manage().Window.Maximize();
            _olimpoksPO = new OlimpoksPO(Driver);
            _olimpoksPO.HandleTelegramPopup();          
            
        }
    
        [Test]
        
        public void TestSolutionsClicking()        {

            _olimpoksPO.ClickSolutionsMenuElement();
            Thread.Sleep(700000);
        }
     
    }
}
