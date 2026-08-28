using OpenQA.Selenium;

namespace SeleniumPomFramework.Pages;

public class CheckoutCompletePage : BasePage
{
    private static readonly By CompleteHeader = By.CssSelector(".complete-header");

    public CheckoutCompletePage(IWebDriver driver) : base(driver) { }

    public string GetConfirmationMessage() => GetText(CompleteHeader);
}
