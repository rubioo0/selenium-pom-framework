using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPomFramework.Config;
using SeleniumPomFramework.Drivers;
using SeleniumPomFramework.Pages;

namespace SeleniumPomFramework.Tests;

[TestFixture]
public class LoginTests
{
    private IWebDriver _driver = null!;
    private LoginPage _loginPage = null!;

    [SetUp]
    public void SetUp()
    {
        _driver = DriverFactory.CreateChromeDriver();
        _loginPage = new LoginPage(_driver);
        _loginPage.Open(TestSettings.BaseUrl);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }

    [Test]
    public void StandardUser_CanLogIn()
    {
        var inventoryPage = _loginPage.LoginAs(TestSettings.StandardUser, TestSettings.Password);
        Assert.That(inventoryPage.IsLoaded(), Is.True);
    }

    [Test]
    public void LockedOutUser_SeesErrorMessage()
    {
        _loginPage.SubmitCredentials(TestSettings.LockedOutUser, TestSettings.Password);
        Assert.That(_loginPage.GetErrorMessage(), Does.Contain("locked out"));
    }

    [Test]
    public void WrongPassword_SeesErrorMessage()
    {
        _loginPage.SubmitCredentials(TestSettings.StandardUser, "wrong_password");
        Assert.That(_loginPage.GetErrorMessage(), Does.Contain("do not match"));
    }
}
