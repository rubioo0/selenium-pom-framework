using OpenQA.Selenium;

namespace SeleniumPomFramework.Pages;

public class CheckoutStepOnePage : BasePage
{
    private static readonly By FirstNameInput = By.Id("first-name");
    private static readonly By LastNameInput = By.Id("last-name");
    private static readonly By PostalCodeInput = By.Id("postal-code");
    private static readonly By ContinueButton = By.Id("continue");

    public CheckoutStepOnePage(IWebDriver driver) : base(driver) { }

    public CheckoutStepTwoPage FillInfoAndContinue(string firstName, string lastName, string postalCode)
    {
        Type(FirstNameInput, firstName);
        Type(LastNameInput, lastName);
        Type(PostalCodeInput, postalCode);
        Click(ContinueButton);
        return new CheckoutStepTwoPage(Driver);
    }
}
