using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestHelper.Selenium
{
    public static class WebDriverExtenstions
    {
        public static bool DoesElementExist(this IWebDriver driver, By by)
        {
            var exists = false;
            try
            {
                driver.FindElement(by);
                exists = true;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element {by.Mechanism}({by.Criteria}) does not exist");
            }
            return exists;
        }

        public static void SaveScreenshot(this IWebDriver driver, string filePathWithName)
        {
            Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
            TakeScreenshot.SaveAsFile($@"{filePathWithName}.Jpeg");
        }

        public static void SavePageSource(this IWebDriver driver, string filePathWithName)
        {
            File.WriteAllText($@"{filePathWithName}.html", driver.PageSource);
        }

        public static bool WaitForUrlToChange(this IWebDriver driver, string currentUrl = "")
        {
            if (string.IsNullOrEmpty(currentUrl))
            {
                currentUrl = driver.Url;
            }
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => !d.Url.Equals(currentUrl));
        }

        public static bool WaitForUrlToContain(this IWebDriver driver, string expectedUrlFragment)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.Url.Contains(expectedUrlFragment));
        }
    }
}
