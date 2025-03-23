using NewReqnrolTestFRamework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;


namespace NewReqnrolTestFRamework.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions 
    {
        LoginPage lpage;
        ProductPage ppage;
        IWebDriver driver;
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = scenarioContext.Get<IWebDriver>("browser"); //step4
            lpage = new LoginPage(driver);
            ppage = new ProductPage(driver);
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

        //Reading from json, resourcefile, note pad, xml, database
        //ScenarioContext
        //Extension


        [Then("user is logged in")]
        public void ThenUserIsLoggedIn()
        {
            var productLabel = ppage.IsProductTitleDisplayed();
            Assert.True(productLabel);
        }

        [Then("the current url contain {string}")]
        public void ThenTheUrlContainInventory(string url)
        {
            var currenturl = ppage.IsUrlContains(url);
            Assert.True(currenturl);
        }
    }
}
