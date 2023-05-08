using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelper.Selenium;

namespace SauceDemo.Pages
{
    public class HomePage : BasePage
    {
        #region selectors
        private By MenuButtonSelector => By.Id("react-burger-menu-btn");
        private By MenuLogoutButtonSelector => By.Id("logout_sidebar_link");

        #endregion selectors

        #region elements

        private IWebElement MenuButton => driver.FindElement(MenuButtonSelector);

        private IWebElement MenuLogoutButton => driver.FindElement(MenuLogoutButtonSelector);

        #endregion elements

        public HomePage(IWebDriver driver) : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("inventory.html"));
        }

        public Login Logout()
        {
            var currentUrl = driver.Url;
            MenuButton.Click();
            MenuLogoutButton.Click();
            driver.WaitForUrlToChange(currentUrl);
            return new Login(driver);
        }
    }
}
