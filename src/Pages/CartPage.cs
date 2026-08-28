using OpenQA.Selenium;

namespace SeleniumPomFramework.Pages;

public class CartPage : BasePage
{
    private static readonly By CartItem = By.CssSelector(".cart_item");
    private static readonly By CheckoutButton = By.Id("checkout");

    public CartPage(IWebDriver driver) : base(driver) { }

    public int GetItemCount() => Driver.FindElements(CartItem).Count;

    public CheckoutStepOnePage Checkout()
    {
        Click(CheckoutButton);
        return new CheckoutStepOnePage(Driver);
    }
}
