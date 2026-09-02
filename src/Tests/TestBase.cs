using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumPomFramework.Drivers;

namespace SeleniumPomFramework.Tests;

public abstract class TestBase
{
    private static readonly string ScreenshotDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshots");

    protected IWebDriver Driver = null!;

    [SetUp]
    public void BaseSetUp()
    {
        Driver = DriverFactory.CreateChromeDriver();
    }

    [TearDown]
    public void BaseTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            TestContext.WriteLine($"Failed on URL: {Driver.Url}");

            Directory.CreateDirectory(ScreenshotDir);
            var path = Path.Combine(ScreenshotDir, $"{TestContext.CurrentContext.Test.Name}.png");
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(path);
            TestContext.WriteLine($"Screenshot saved: {path}");
        }

        Driver.Quit();
    }
}
