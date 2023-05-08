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

        private IWebElement LoginField => driver.FindElement(LoginFieldSelector);

        private IWebElement PasswordField => driver.FindElement(PasswordFieldSelector);

        private IWebElement LoginButton => driver.FindElement(LoginButtonSelector);

        private IWebElement ErrorMessage => driver.FindElement(ErrorMessageSelector);

        #endregion elements

        public Login(IWebDriver driver) :base(driver)
        {

        }

        public static Login Visit(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            return new Login(driver);
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
            return (T)Activator.CreateInstance(typeof(T), driver);
        }

        public bool IsErrorMessageVisible()
        {
            return (driver.DoesElementExist(ErrorMessageSelector) & ErrorMessage.Displayed);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}
