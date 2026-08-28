using OpenQA.Selenium;

namespace SeleniumPomFramework.Pages;

public class InventoryPage : BasePage
{
    private static readonly By InventoryList = By.CssSelector(".inventory_list");
    private static readonly By CartBadge = By.CssSelector(".shopping_cart_badge");
    private static readonly By CartLink = By.CssSelector(".shopping_cart_link");

    public InventoryPage(IWebDriver driver) : base(driver) { }

    public bool IsLoaded() => Driver.FindElements(InventoryList).Count > 0;

    public void AddItemToCart(string itemName) => Click(ItemButtonFor(itemName));

    public void RemoveItemFromCart(string itemName) => Click(ItemButtonFor(itemName));

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

    private static By ItemButtonFor(string itemName) =>
        By.XPath($"//div[@class='inventory_item_name' and text()='{itemName}']/ancestor::div[@class='inventory_item']//button");
}
