using NUnit.Framework;

namespace TermikaSelenium4
{
    public class OlimpoksTests : BaseTest
    {
        private OlimpoksPO _olimpoksPO;
        [SetUp]
        public void SetUp()
        {
            Driver.Manage().Window.Maximize();
            _olimpoksPO = new OlimpoksPO(Driver);
            _olimpoksPO.HandleTelegramPopup();
            _olimpoksPO._clickSoltionsMenuElement();
            
        }
    
        [Test]
        
        public void TestSolutionsClicking()
        {          

            _olimpoksPO.ClickCatalogButton();
            Thread.Sleep(7000);
        }
     
    }
}
