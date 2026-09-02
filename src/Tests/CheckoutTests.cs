using NUnit.Framework;
using SeleniumPomFramework.Config;
using SeleniumPomFramework.Pages;

namespace SeleniumPomFramework.Tests;

[TestFixture]
public class CheckoutTests : TestBase
{
    private InventoryPage _inventoryPage = null!;

    [SetUp]
    public void SetUp()
    {
        var loginPage = new LoginPage(Driver);
        loginPage.Open(TestSettings.BaseUrl);
        _inventoryPage = loginPage.LoginAs(TestSettings.StandardUser, TestSettings.Password);
    }

    [Test]
    public void FullCheckoutFlow_CompletesSuccessfully()
    {
        _inventoryPage.AddItemToCart("Sauce Labs Backpack");
        var cartPage = _inventoryPage.GoToCart();
        var checkoutStepOne = cartPage.Checkout();
        var checkoutStepTwo = checkoutStepOne.FillInfoAndContinue("Andriy", "V", "12345");

        Assert.That(checkoutStepTwo.GetTotal(), Does.Contain("$"));

        var completePage = checkoutStepTwo.Finish();
        Assert.That(completePage.GetConfirmationMessage(), Does.Contain("Thank you"));
    }
}
