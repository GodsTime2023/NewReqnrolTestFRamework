namespace NewReqnrolTestFRamework.Drivers
{
    public class InitializeDriver
    {
        public required IWebDriver driver;
        public required ChromeOptions options;

        public IWebDriver Start()
        {
            options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad
                = TimeSpan.FromSeconds(10);
            return driver;
        }

        public void ShutDownBrowser()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
