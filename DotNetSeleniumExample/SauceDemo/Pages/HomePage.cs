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

        private By ShopppingCartBadgeSelector => By.ClassName("shopping_cart_badge");

        private By AddToButtonSelector(string itemName) => By.XPath($"//*[@class='inventory_item'][.//*[text()='{itemName}']]//button[text()='Add to cart']");

        #endregion selectors

        #region elements

        private IWebElement MenuButton => Driver.FindElement(MenuButtonSelector);

        private IWebElement MenuLogoutButton => Driver.FindElement(MenuLogoutButtonSelector);

        private IWebElement ShoppingCartBadge => Driver.FindElement(ShopppingCartBadgeSelector);

        #endregion elements

        public HomePage(IWebDriver driver) : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("inventory.html"));
        }

        public Login Logout()
        {
            var currentUrl = Driver.Url;
            MenuButton.Click();
            MenuLogoutButton.Click();
            Driver.WaitForUrlToChange(currentUrl);
            return new Login(Driver);
        }

        public void ClickAddToCart(string itemName)
        {
            var addToCartButton = Driver.FindElement(AddToButtonSelector(itemName));
            addToCartButton.Click();
        }

        public bool IsShoppingCartBadgeDisplayed()
        {
            if (!Driver.DoesElementExist(ShopppingCartBadgeSelector)) 
            {
                return false;
            }

            return ShoppingCartBadge.Displayed;
        }

        public int GetShoppingCartItemCount()
        {
            var itemCount = ShoppingCartBadge.Text;
            return Convert.ToInt32(itemCount);
        }
    }
}
