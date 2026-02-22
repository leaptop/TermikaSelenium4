using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TermikaSelenium4.Pages
{
    public class OlimpoksPO : OlimpoksBasePO
    {
        
       
        public OlimpoksPO(IWebDriver driver) : base(driver)
        {
            Driver = driver;
       

        }

       

    }
}
