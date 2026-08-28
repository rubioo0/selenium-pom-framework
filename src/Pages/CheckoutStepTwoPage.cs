using OpenQA.Selenium;

namespace SeleniumPomFramework.Pages;

public class CheckoutStepTwoPage : BasePage
{
    private static readonly By FinishButton = By.Id("finish");
    private static readonly By TotalLabel = By.CssSelector(".summary_total_label");

    public CheckoutStepTwoPage(IWebDriver driver) : base(driver) { }

    public string GetTotal() => GetText(TotalLabel);

    public CheckoutCompletePage Finish()
    {
        Click(FinishButton);
        return new CheckoutCompletePage(Driver);
    }
}
