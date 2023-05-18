using OpenQA.Selenium;
using TestHelper.Selenium;

namespace SauceDemo.Pages
{
    public class Login : BasePage
    {
        #region Selectors
        private By LoginFieldSelector => By.Id("user-name");
        private By PasswordFieldSelector => By.Id("password");
        private By LoginButtonSelector => By.Id("login-button");
        private By ErrorMessageSelector => By.XPath("//*[@data-test='error']");
        #endregion selectors

        #region elements

        private IWebElement LoginField => Driver.FindElement(LoginFieldSelector);

        private IWebElement PasswordField => Driver.FindElement(PasswordFieldSelector);

        private IWebElement LoginButton => Driver.FindElement(LoginButtonSelector);

        private IWebElement ErrorMessage => Driver.FindElement(ErrorMessageSelector);

        #endregion elements

        public Login(IWebDriver driver) :base(driver)
        {

        }

        public static Login Visit(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            return new Login(driver);
        }

        public static HomePage VisitAndLogin(IWebDriver driver, string userName, string password)
        {
            var page = Visit(driver);
            page.SetUserName(userName);
            page.SetPassword(password);
            return page.ClickLoginButton<HomePage>();
        }

        public void SetUserName(string userName)
        {
            LoginField.SendKeys(userName);
        }

        public void SetPassword(string password) 
        {
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public T ClickLoginButton<T>() where T : BasePage
        {
            LoginButton.Click();
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }

        public bool IsErrorMessageVisible()
        {
            return (Driver.DoesElementExist(ErrorMessageSelector) & ErrorMessage.Displayed);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}
