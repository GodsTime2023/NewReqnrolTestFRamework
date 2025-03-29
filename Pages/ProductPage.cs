namespace NewReqnrolTestFRamework.Pages
{
    public class ProductPage 
    {
        IWebDriver driver;
        public ProductPage(IWebDriver _driver) 
        {
            driver = _driver;
        }

        private IWebElement productTitle =>
                driver.FindElement(
                    By.XPath("//span[@class='title']"));
        public bool IsProductTitleDisplayed() => productTitle.Displayed;
        public string GetProductTitleText() => productTitle.Text;
        private IReadOnlyCollection<IWebElement> addToCartButton => driver.FindElements(By.XPath("//div[@class='inventory_item_description']//button"));
        private IReadOnlyCollection<IWebElement> productNames => driver.FindElements(By.XPath("//div[@class='inventory_item_description']//a"));
        private IWebElement AddProdToCartByName(string prodName) => driver.FindElement(By.XPath($"//div[text()='{prodName}']//ancestor::div[@data-test='inventory-item-description']//button"));
        private IWebElement MenuIcon => driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement LogoutBtn => driver.FindElement(By.Id("logout_sidebar_link"));
        private IWebElement cartIcon => driver.FindElement(By.CssSelector("[data-test='shopping-cart-link']"));


        public void AddProductToCartByCount(int productCount, string steptext="")
        {
            if (productCount > addToCartButton.Count)
            {
                throw new ArgumentException($"you cannot exceed max count: {addToCartButton.Count}",$"Step: {steptext}");
            }
            else
            {
                for (int i = 0; i < productCount; i++)
                {
                    addToCartButton.ElementAt(i).Click();
                }
            }
        }

        public Dictionary<string, string> AddProductNames()
        {
            var context = productNames
                .Select((el, i) => new { i, el.Text })
                .ToDictionary(item => item.i.ToString(), item => item.Text);
            return context;
        }

        public void ClickCartIcon() => cartIcon.Click();

        public void ClickMenuAndLogout()
        {
            MenuIcon.Click();
            LogoutBtn.Click();
        }

        public bool IsUrlContains(string url) => driver.Url.Contains(url);

        public void AddProductToCartByName(DataTable table)
        {
            foreach (var item in table.Rows)
            {
                AddProdToCartByName(item.First().Value).Click();
            }
        }
    }
}
