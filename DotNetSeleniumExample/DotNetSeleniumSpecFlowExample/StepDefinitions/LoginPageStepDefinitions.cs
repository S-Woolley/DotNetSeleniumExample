using DotNetSeleniumSpecFlowExample.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;
using System;
using TechTalk.SpecFlow;

namespace DotNetSeleniumSpecFlowExample.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitions : BaseDefinition
    {
        private Login? page;

        public LoginPageStepDefinitions(BrowserDriver browserDriver) : base(browserDriver) 
        {

        }

        [Given(@"A login page")]
        public void GivenALoginPage()
        {
            page = Login.Visit(Driver);
        }

        [When(@"The login button is clicked")]
        public void WhenTheLoginButtonIsClicked()
        {
            page.ClickLoginButton();
        }

        [Then(@"an error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            var isErrorMessageVisible = page.IsErrorMessageVisible();
            isErrorMessageVisible.Should().BeTrue();
        }

        [Then(@"error message should say '([^']*)'")]
        public void ThenErrorMessageShouldSay(string errorMessage)
        {
            var errorMesage = page.GetErrorMessage();
            errorMesage.Should().Be(errorMessage);
        }

        [Given(@"'([^']*)' is entered for the username")]
        public void GivenIsEnteredForTheUsername(string username)
        {
            page.SetUserName(username);
        }

        [Given(@"'([^']*)' is entered for the password")]
        public void GivenIsEnteredForThePassword(string password)
        {
            page.SetPassword(password);
        }



    }
}
