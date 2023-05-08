using NUnit.Framework;
using SauceDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSeleniumExample.Tests
{
    internal class HomePageTests :BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public void BeforeAll()
        {
            var page = Login.Visit(driver);
            page.SetUserName("standard_user");
            page.SetPassword("secret_sauce");
            homePage = page.ClickLoginButton<HomePage>();
        }

        [Test]
        public void Logout()
        {
            var loginPage = homePage.Logout();
            Assert.AreEqual("https://www.saucedemo.com/", loginPage.PageURL, "URL post logout");
        }
    }
}
