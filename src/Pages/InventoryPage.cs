using OpenQA.Selenium;

namespace SeleniumPomFramework.Pages;

public class InventoryPage : BasePage
{
    private static readonly By InventoryList = By.CssSelector(".inventory_list");
    private static readonly By CartBadge = By.CssSelector(".shopping_cart_badge");
    private static readonly By CartLink = By.CssSelector(".shopping_cart_link");

    public InventoryPage(IWebDriver driver) : base(driver) { }

    public bool IsLoaded() => Driver.FindElements(InventoryList).Count > 0;

    public void AddItemToCart(string itemName) => Click(By.Id($"add-to-cart-{Slug(itemName)}"));

    public void RemoveItemFromCart(string itemName) => Click(By.Id($"remove-{Slug(itemName)}"));

    public int GetCartCount()
    {
        var badges = Driver.FindElements(CartBadge);
        return badges.Count == 0 ? 0 : int.Parse(badges[0].Text);
    }

    public CartPage GoToCart()
    {
        Click(CartLink);
        return new CartPage(Driver);
    }

    private static string Slug(string itemName) => itemName.ToLowerInvariant().Replace(" ", "-");
}
