using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V111.DOM;
using SauceDemo.Pages;

namespace DotNetSeleniumExample.Tests
{
    internal class LoginTests : BaseTest
    {
        private const string standardUser = "standard_user";
        private const string password = "secret_sauce";

        [Test]
        public void NoLoginNameAndPassword()
        {
            var page = Login.Visit(Driver);
            page.ClickLoginButton();
            Assert.IsTrue(page.IsErrorMessageVisible(), "Error Message Visible");
            Assert.AreEqual("Epic sadface: Username is required", page.GetErrorMessage(), "Error Message Text");
        }

        [Test]
        public void NoPassword()
        {
            var page = Login.Visit(Driver);
            page.SetUserName(standardUser);
            page.ClickLoginButton();

            Assert.IsTrue(page.IsErrorMessageVisible(), "Error Message Visible");
            Assert.AreEqual("Epic sadface: Password is required", page.GetErrorMessage(), "Error Message Text");
        }

        [Test]
        public void IncorrectPassword()
        {
            var page = Login.Visit(Driver);
            page.SetUserName(standardUser);
            page.SetPassword("Wrong");
            page.ClickLoginButton();

            Assert.IsTrue(page.IsErrorMessageVisible(), "Error Message Visible");
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service",
                page.GetErrorMessage(), "Error Message Text");
        }

        [Test]
        public void SuccesfulLogin()
        {
            var page = Login.Visit(Driver);
            page.SetUserName(standardUser);
            page.SetPassword(password);
            var homePage = page.ClickLoginButton<HomePage>();

            Assert.AreEqual("https://www.saucedemo.com/inventory.html",
                homePage.PageURL, "URL");
        }
    }
}
