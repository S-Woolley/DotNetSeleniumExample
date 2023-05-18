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
        protected IWebDriver Driver { get; private set; }

        public string PageURL => Driver.Url;

        protected BasePage(IWebDriver driver) 
        { 
            this.Driver = driver;
        }

    }
}
