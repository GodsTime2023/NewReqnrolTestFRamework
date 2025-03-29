namespace NewReqnrolTestFRamework.Extensions
{
    public static class DriverExtension
    {
       public static IWebElement FindById(
           this IWebDriver driver, string locator)
       {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return wait.Until(_ => driver.FindElement(By.Id(locator)));
       }

        public static IWebElement FindByName(
           this IWebDriver driver, string locator)
        {
            return driver.FindElement(By.Name(locator));
        }

        public static IWebElement FindByXpath(
           this IWebDriver driver, string locator)
        {
            return driver.FindElement(By.XPath(locator));
        }
    }

    public static class WebElementExtension
    {
        public static void SetText(this IWebElement element,
            string value) => element.SendKeys(value);
    }
}
