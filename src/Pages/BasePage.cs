using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPomFramework.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement WaitForVisible(By locator) =>
        Wait.Until(d =>
        {
            var element = d.FindElement(locator);
            return element.Displayed ? element : null;
        })!;

    protected IWebElement WaitForClickable(By locator) =>
        Wait.Until(d =>
        {
            var element = d.FindElement(locator);
            return element.Displayed && element.Enabled ? element : null;
        })!;

    protected void Click(By locator) => WaitForClickable(locator).Click();

    protected void Type(By locator, string text)
    {
        var element = WaitForVisible(locator);
        element.Clear();
        element.SendKeys(text);
    }

    protected string GetText(By locator) => WaitForVisible(locator).Text;
}
