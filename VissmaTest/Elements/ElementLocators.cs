using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaTest.Elements
{
    public static class ElementLocators
    {
        // Elements
        public static By ResourcesButton => By.XPath("/html/body/div/header/div[1]/div/nav/div[2]/button/span");
        public static By StartHereButton => By.XPath("/html/body/div/header/div[1]/div/nav/div[2]/div/div/div/a[2]/div/div/div/p[1]");
        public static By SearchInput => By.XPath("//*[@name='search']");
        public static By SearchResultsContainer => By.XPath("//*[@id='hits']/div/div");
        public static By MembersSlider => By.Id("members");
        public static By PricingSectionLink => By.XPath("/html/body/div[1]/header/div[1]/div/nav/a[2]");
        public static By StarterPrice => By.XPath("/html/body/div/main/div[1]/div[1]/div[4]/div[2]/div[1]/div/div/div/p");
        public static By CreatorPrice => By.XPath("/html/body/div/main/div[1]/div[1]/div[4]/div[2]/div[2]/div/div/div/p");
        public static By TeamPrice => By.XPath("/html/body/div/main/div[1]/div[1]/div[4]/div[2]/div[3]/div/div/div/p");
        public static By BusinessPrice => By.XPath("/html/body/div/main/div[1]/div[1]/div[4]/div[2]/div[4]/div/div/div/p");

        // Methods for interacting with elements
        public static void ClickResourcesButton(IWebDriver driver)
        {
            driver.FindElement(ResourcesButton).Click();
        }

        public static void ClickStartHereButton(IWebDriver driver)
        {
            driver.FindElement(StartHereButton).Click();
        }

        public static void EnterSearchText(IWebDriver driver, string searchText)
        {
            driver.FindElement(SearchInput).SendKeys(searchText);
        }

        public static Dictionary<string, string> GetPrices(IWebDriver driver)
        {
            Dictionary<string, string> prices = new Dictionary<string, string>();

            // Get initial prices
            prices["InitialStarterPrice"] = driver.FindElement(StarterPrice).Text;
            prices["InitialCreatorPrice"] = driver.FindElement(CreatorPrice).Text;
            prices["InitialTeamPrice"] = driver.FindElement(TeamPrice).Text;
            prices["InitialBusinessPrice"] = driver.FindElement(BusinessPrice).Text;

            // Move the slider to update the prices
            MoveSliderToKMembers(driver, 20.512820512820515);

            // Wait for the prices to update 
            Thread.Sleep(3000); 

            // Get updated prices
            prices["UpdatedStarterPrice"] = driver.FindElement(StarterPrice).Text;
            prices["UpdatedCreatorPrice"] = driver.FindElement(CreatorPrice).Text;
            prices["UpdatedTeamPrice"] = driver.FindElement(TeamPrice).Text;
            prices["UpdatedBusinessPrice"] = driver.FindElement(BusinessPrice).Text;

            return prices;
        }

        public static void MoveSliderToKMembers(IWebDriver driver, double targetPercentage)
        {
            int maxValue = 39;
            int targetValue = (int)(maxValue * targetPercentage / 100.0);
            IWebElement slider = driver.FindElement(MembersSlider);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = {targetValue};", slider);
            js.ExecuteScript("var event = new Event('input', { bubbles: true }); arguments[0].dispatchEvent(event);", slider);
        }

        public static void ClickPricingSectionLink(IWebDriver driver)
        {
            driver.FindElement(PricingSectionLink).Click();
        }

        public static void ClickTenthSearchResult(IWebDriver driver)
        {
            // Find the container of the search results
            IWebElement searchResultsContainer = driver.FindElement(By.XPath("//*[@id='hits']/div/div"));

            // Find all search results within the container
            IReadOnlyList<IWebElement> searchResults = searchResultsContainer.FindElements(By.XPath("./ol/li"));

            // Check if there are at least 10 search results
            if (searchResults.Count >= 10)
            {
                // Click on the 10th search result
                searchResults[9].Click();
            }
            else
            {
                throw new NoSuchElementException("There are less than 10 search results.");
            }
        }
    }
}
