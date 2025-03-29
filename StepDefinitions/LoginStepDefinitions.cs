namespace NewReqnrolTestFRamework.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions 
    {
        private readonly LoginPage lpage;
        private readonly ProductPage ppage;
        private readonly IWebDriver driver;
        private readonly CartPage cpage;
        ScenarioContext scenarioContext;
        public LoginStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext.Get<IWebDriver>("browser");
            lpage = new LoginPage(driver);
            ppage = new ProductPage(driver);
            cpage = new CartPage(driver);
        }

        [Given("user is on saucedemo login page")]
        public void GivenUserIsOnSaucedemoLoginPage()
        {
            lpage.NavigateToSite();
        }

        [When("user enters login credentials {string}, {string}")]
        public void WhenUserEntersLoginCredentials(string username,
            string password)
        {
            lpage.EnterCredentials(username, password);
        }

        [When("user enters {string} login credentials {string}, {string}")]
        public void WhenUserEntersLoginCredentials(string option, string username, string password)
        {
            if (option == "valid")
            {
                lpage.EnterCredentials(username, password);
            }else if(option == "invalid")
            {
                lpage.EnterCredentials(username, password);
            }
        }

        public class MyTableData
        {
            public string username;
            public string password;
        }

        [When("user enters login credentials")]
        public void WhenUserEntersLoginCredentials(DataTable dataTable)
        {
            lpage.EnterCredentials(
                dataTable.Rows[0]["username"],
                dataTable.Rows[0]["password"]);
        }

        [Then("user is logged in")]
        public void ThenUserIsLoggedIn()
        {
            var productLabel = ppage.IsProductTitleDisplayed();
            var productText = ppage.GetProductTitleText();
            Assert.True(productLabel);
            Assert.That(productText, Is.EqualTo("Products"));
        }

        [Then("the current url contain {string}")]
        public void ThenTheUrlContainInventory(string url)
        {
            var currenturl = ppage.IsUrlContains(url);
            Assert.True(currenturl);
        }

        [When("I view the basket")]
        public void WhenIViewTheBasket()
        {
            ppage.ClickCartIcon();
            Thread.Sleep(2000);
        }

        [When("I add {int} products to cart")]
        public void WhenIAddProducts(int productCount)
        {
            var stepText = scenarioContext.StepContext.StepInfo.Text;
            ppage.AddProductToCartByCount(productCount, stepText);
        }

        [When("I add the following products")]
        public void WhenIAddTheFollowingProducts(DataTable dataTable)
        {
            ppage.AddProductToCartByName(dataTable);
        }

        [Then("I verify product count is {int}")]
        public void ThenIVerifyProductCountIs(int expectedProductCount)
        {
            var actualCount = cpage.GetProdCount();
            if (expectedProductCount > actualCount)
            {
                var stepText = scenarioContext.StepContext.StepInfo.Text;
                throw new ArgumentException(
                    $"Total count is {actualCount}", $"Step: {stepText}");
            }
            else
            {
                Assert.That(actualCount, Is.EqualTo(expectedProductCount),
                $"Actual count: {actualCount}");
            }
        }

        [When("I save product names as {string}")]
        public void WhenISaveProductNamesAs(string products)
        {
            scenarioContext.Add(products, ppage.AddProductNames());
        }

        [Then("I verify {int} product names from {string}")]
        public void ThenIVerifyProductNamesAs(int count, string products)
        {
            var expected = scenarioContext.Get<Dictionary<string, string>>(products);
            if (count > expected.Count)
            {
                var stepText = scenarioContext.StepContext.StepInfo.Text;
                throw new ArgumentException(
                    $"Total available count is {expected.Count}", $"Step: {stepText}");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    var expectedProductName = expected[i.ToString()];
                    var actualProductName = cpage.GetProductName(expectedProductName);
                    Assert.That(actualProductName, Is.EqualTo(expectedProductName));
                }
            }
        }

        [Then("I verify product names as")]
        public void ThenIVerifyProductNamesAs(DataTable dataTable)
        {
            var expected = dataTable.Rows.Select(x => x[0]).ToList(); //get all datas from table
            for (int i = 0; i < expected.Count; i++)
            {
                var actual = cpage.GetProductName(dataTable.Rows[i].Values.First()); //Get datas from cart by index of table name
                Assert.That(expected[i], Is.EqualTo(actual)); //Assert expected and actual by index
            }
        }
    }
}
