using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestHelper.Selenium;

namespace DotNetSeleniumExample.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver { get; private set; }

        private string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        protected string TestName => TestContext.CurrentContext.Test.FullName;

        [SetUp]
        public void BaseBeforeAll()
        {
            if (Directory.Exists(TestName))
            {
                Directory.Delete(TestName, true);
            }
            Directory.CreateDirectory(TestName);
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void BaseAfterAll()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                try
                {
                    TestContext.Out.WriteLine("Test Failed: Grabbing Evidence");
                    driver.SaveScreenshot($@"{AssemblyLocation}\{TestName}\Failure");
                    driver.SavePageSource($@"{AssemblyLocation}\{TestName}\Failure");
                }
                catch (Exception ex) 
                {
                    TestContext.Out.WriteLine($"Error Grabbing Evidence {ex.Message}");
                }
                
            }
            driver.Quit();
        }
    }
}
