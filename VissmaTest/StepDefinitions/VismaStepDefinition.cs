using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using VismaTest.Support;
using BoDi;
using VismaTest.Elements;

namespace VismaTest.StepDefinitions
{
    [Binding]
    public class VismaStepDefinitions
    {
        private readonly IWebDriver driver;

        public VismaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"the user goes to Resources Section")]
        public void GivenTheUserGoesToResourcesSection()
        {
            ElementLocators.ClickResourcesButton(driver);
            Thread.Sleep(3000);
        }

        [When(@"the user gets to Start Here section")]
        public void WhenTheUserGetsToStartHereSection()
        {
            ElementLocators.ClickStartHereButton(driver);
            Thread.Sleep(3000);
        }

        [Then(@"search for Create New Blog")]
        public void ThenSearchForCreateNewBlog()
        {
            ElementLocators.EnterSearchText(driver, "create new blog");
            Thread.Sleep(3000);
        }

        [Then(@"click on the 10th result")]
        public void ThenOpenTheTenthSearchResult()
        {
            ElementLocators.ClickTenthSearchResult(driver);
        }

        [Then(@"scroll to the top and open Pricing Section")]
        public void ThenScrollToTheTopAndOpenPricingSection()
        {
            // Scroll to the top and click on the Pricing Section
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0);");
            Thread.Sleep(2000);
            ElementLocators.ClickPricingSectionLink(driver);
            Thread.Sleep(2000);
        }

        [Then(@"verify the prices get updated when moving the slider to (.*)k members")]
        public void ThenVerifyThePricesGetUpdatedWhenMovingTheSliderToKMembers(int targetValue)
        {
            // Get initial prices      
            Dictionary<string, string> prices = ElementLocators.GetPrices(driver);
            // Assert that the updated prices are different from the initial prices for all four tiers
            ClassicAssert.AreNotEqual(prices["InitialStarterPrice"], prices["UpdatedStarterPrice"], "Starter price did not get updated after moving the slider");
            ClassicAssert.AreNotEqual(prices["InitialCreatorPrice"], prices["UpdatedCreatorPrice"], "Creator price did not get updated after moving the slider");
            ClassicAssert.AreNotEqual(prices["InitialTeamPrice"], prices["UpdatedTeamPrice"], "Team price did not get updated after moving the slider");
            ClassicAssert.AreNotEqual(prices["InitialBusinessPrice"], prices["UpdatedBusinessPrice"], "Business price did not get updated after moving the slider");
            ElementLocators.MoveSliderToKMembers(driver, 20.512820512820515);
        }

    }
}
