using DotNetSeleniumSpecFlowExample.Drivers;
using OpenQA.Selenium;
using SauceDemo.Pages;
using System;
using TechTalk.SpecFlow;

namespace DotNetSeleniumSpecFlowExample.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinitions : BaseDefinition
    {
        private Login? page;
        private HomePage? homePage;

        public HomePageStepDefinitions(BrowserDriver browserDriver) : base(browserDriver)
        {
            homePage = Login.VisitAndLogin(Driver, "standard_user", "secret_sauce");
        }


        [Given(@"I am logged in as a standard user on the home page")]
        public void GivenIAmLoggedInAsAStandardUserOnTheHomePage()
        {
            
        }

        [When(@"I click add to cart for (.*)")]
        public void WhenIClickAddToCartFor(string item)
        {
            homePage.ClickAddToCart(item);
        }

        [Then(@"the checkout cart total equals '([^']*)'")]
        public void ThenTheCheckoutCartTotalEquals(int total)
        {
            homePage.IsShoppingCartBadgeDisplayed().Should().BeTrue();
            homePage.GetShoppingCartItemCount().Should().Be(total);
        }


        [When(@"I click logout")]
        public void WhenIClickLogout()
        {
            homePage.Logout();
        }

        [Then(@"I am taken to the home page")]
        public void ThenIAmTakenToTheHomePage()
        {
            homePage.PageURL.Should().Be("https://www.saucedemo.com/");
        }

    }
}
