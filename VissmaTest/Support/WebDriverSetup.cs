using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace VismaTest.Support
{
    [Binding]
    public class SeleniumSpecFlowHooks
    {
        private readonly IObjectContainer container;

        public SeleniumSpecFlowHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            // Create and configure an instance of IWebDriver 
            IWebDriver driver = new ChromeDriver();
            // Register the WebDriver instance
            container.RegisterInstanceAs(driver);
            driver.Navigate().GoToUrl("https://ghost.org/");
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            // Retrieve the WebDriver instance from the container
            IWebDriver driver = container.Resolve<IWebDriver>();

            // Close and dispose of the WebDriver instance
            driver.Quit();
            driver.Dispose();
        }
    }
}