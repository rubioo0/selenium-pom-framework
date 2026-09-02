using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumPomFramework.Drivers;

namespace SeleniumPomFramework.Tests;

public abstract class TestBase
{
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
            TestContext.WriteLine(Driver.PageSource);
        }

        Driver.Quit();
    }
}
