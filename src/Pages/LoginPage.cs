using OpenQA.Selenium;

namespace SeleniumPomFramework.Pages;

public class LoginPage : BasePage
{
    private static readonly By UsernameInput = By.Id("user-name");
    private static readonly By PasswordInput = By.Id("password");
    private static readonly By LoginButton = By.Id("login-button");
    private static readonly By ErrorMessage = By.CssSelector("[data-test='error']");

    public LoginPage(IWebDriver driver) : base(driver) { }

    public void Open(string baseUrl) => Driver.Navigate().GoToUrl(baseUrl);

    public void SubmitCredentials(string username, string password)
    {
        Type(UsernameInput, username);
        Type(PasswordInput, password);
        Click(LoginButton);
    }

    public InventoryPage LoginAs(string username, string password)
    {
        SubmitCredentials(username, password);
        return new InventoryPage(Driver);
    }

    public string GetErrorMessage() => GetText(ErrorMessage);
}
