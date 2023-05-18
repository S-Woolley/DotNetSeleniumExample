using DotNetSeleniumSpecFlowExample.Drivers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestHelper.Selenium;

namespace DotNetSeleniumSpecFlowExample.StepDefinitions
{
    public abstract class BaseDefinition
    {
        protected IWebDriver Driver { get; private set; }

        private string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private string TestName { get;set; }

        public BaseDefinition(BrowserDriver browserDriver)
        {
            Driver = browserDriver.Current;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenario) 
        {
            TestName = scenario.ScenarioInfo.Title.Replace(" ", string.Empty);
            if(Directory.Exists(TestName))
            {
                Directory.Delete(TestName, true);
            }
            Directory.CreateDirectory(TestName);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenario)
        {
            if (scenario.ScenarioExecutionStatus.ToString() != "OK")
            {
                Driver.SaveScreenshot($@"{AssemblyLocation}\{TestName}\Failure");
                Driver.SavePageSource($@"{AssemblyLocation}\{TestName}\Failure");
            }
        }
    }
}
