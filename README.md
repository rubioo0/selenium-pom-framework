# Selenium POM Framework

A Page Object Model test automation framework in C#/.NET, built against [saucedemo.com](https://www.saucedemo.com/) - the standard public site for this kind of demo.

Structure mirrors what I've built and worked with on real projects: a base page class with explicit waits, one page object per screen, tests kept separate from page logic, config pulled into its own file. Selenium 4's built-in driver management handles the ChromeDriver version matching, so there's nothing extra to install.

Covers login (including the locked-out and wrong-password cases), cart add/remove, and a full checkout flow.

## Run it

    dotnet restore src/SeleniumPomFramework.csproj
    dotnet test src/SeleniumPomFramework.csproj

Runs headless by default. CI runs the same suite on every push via GitHub Actions.
