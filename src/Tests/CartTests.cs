using NUnit.Framework;
using SeleniumPomFramework.Config;
using SeleniumPomFramework.Pages;

namespace SeleniumPomFramework.Tests;

[TestFixture]
public class CartTests : TestBase
{
    private const string Item = "Sauce Labs Backpack";

    private InventoryPage _inventoryPage = null!;

    [SetUp]
    public void SetUp()
    {
        var loginPage = new LoginPage(Driver);
        loginPage.Open(TestSettings.BaseUrl);
        _inventoryPage = loginPage.LoginAs(TestSettings.StandardUser, TestSettings.Password);
    }

    [Test]
    public void AddingItem_UpdatesCartBadge()
    {
        _inventoryPage.AddItemToCart(Item);
        Assert.That(_inventoryPage.GetCartCount(), Is.EqualTo(1));
    }

    [Test]
    public void RemovingItem_ClearsCartBadge()
    {
        _inventoryPage.AddItemToCart(Item);
        _inventoryPage.RemoveItemFromCart(Item);
        Assert.That(_inventoryPage.GetCartCount(), Is.EqualTo(0));
    }

    [Test]
    public void CartPage_ShowsAddedItem()
    {
        _inventoryPage.AddItemToCart(Item);
        var cartPage = _inventoryPage.GoToCart();
        Assert.That(cartPage.GetItemCount(), Is.EqualTo(1));
    }
}
