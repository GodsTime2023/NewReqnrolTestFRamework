namespace NewReqnrolTestFRamework.Pages
{
    public class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IReadOnlyCollection<IWebElement> prodCount =>
            driver.FindElements(By.CssSelector("[data-test='inventory-item']"));
        private IWebElement CartProductDisplayedName(string name) =>
            driver.FindElement(By.XPath($"//div[text()='{name}']"));

        public int GetProdCount() => prodCount.Count;
        public string GetProductName(string name) => CartProductDisplayedName(name).Text;
    }
}
