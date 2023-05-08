using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public string PageURL => driver.Url;

        protected BasePage(IWebDriver driver) 
        { 
            this.driver = driver;
        }

    }
}
