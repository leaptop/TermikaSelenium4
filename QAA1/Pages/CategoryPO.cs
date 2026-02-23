using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermikaSelenium4.Pages
{
    internal class CategoryPO : OlimpoksBasePO
    {
        public CategoryPO(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

    }
}
