using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPomFramework.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateChromeDriver(bool headless = true)
    {
        var options = new ChromeOptions();
        if (headless)
        {
            options.AddArgument("--headless=new");
        }
        options.AddArgument("--window-size=1280,800");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        return new ChromeDriver(options);
    }
}
