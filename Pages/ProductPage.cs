using OpenQA.Selenium;

namespace NewReqnrolTestFRamework.Pages
{
    public class ProductPage 
    {
        IWebDriver driver;
        public ProductPage(IWebDriver _driver) 
        {
            driver = _driver;
        }

        IWebElement productTitle =>
                driver.FindElement(
                    By.XPath("//span[@class='title']"));

        public bool IsProductTitleDisplayed() => productTitle.Displayed;

        public bool IsUrlContains(string url) => driver.Url.Contains(url);
    }
}
