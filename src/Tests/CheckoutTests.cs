using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPomFramework.Config;
using SeleniumPomFramework.Drivers;
using SeleniumPomFramework.Pages;

namespace SeleniumPomFramework.Tests;

[TestFixture]
public class CheckoutTests
{
    private IWebDriver _driver = null!;
    private InventoryPage _inventoryPage = null!;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverFactory.CreateChromeDriver();
        var loginPage = new LoginPage(_driver);
        loginPage.Open(TestSettings.BaseUrl);
        _inventoryPage = loginPage.LoginAs(TestSettings.StandardUser, TestSettings.Password);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
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
