using NUnit.Framework;

namespace TermikaSelenium4
{
    public class OlimpoksTests : BaseTest
    {
        private OlimpoksPO _olimpoksPO;
        [SetUp]
        public void SetUp()
        {
            PopUpHandler htp = new PopUpHandler(Driver);
            Driver.Manage().Window.Maximize();
            _olimpoksPO = new OlimpoksPO(Driver);
            htp.HandleTelegramPopup();
            
        }
    
        [Test]
        
        public void TestSolutionsClicking()
        {          

            _olimpoksPO.ClickCatalogButton();
            Thread.Sleep(7000);
        }
     
    }
}
