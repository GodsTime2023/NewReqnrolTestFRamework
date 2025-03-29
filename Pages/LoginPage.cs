namespace NewReqnrolTestFRamework.Pages
{
    public class LoginPage 
    {
        IWebDriver driver;
        public LoginPage(IWebDriver _driver) 
        {
            driver = _driver;
        }

        IWebElement userName => driver.FindById("user-name");
 
        IWebElement passWord => driver.FindElement(By.Id("password"));
        
        IWebElement loginBtn => driver.FindElement(By.Id("login-button"));
               

        public void NavigateToSite()
        {
            var readFromJson = new readFromJson();
            var url = readFromJson.geturlValue("url:suacedemoUrl");

            ////var urlFromTextFile =
            ////    readFromTextFile.FromTextFile().Split("\r\n").First();

            driver.Navigate().GoToUrl(url);
        }

        public void EnterCredentials(string username, string password)
        {
            userName.SetText(username);
            passWord.SetText(password);
            loginBtn.Click();
        }
    }
}
