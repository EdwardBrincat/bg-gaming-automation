using Bg_Playwright_WebDriver_Client;
using Bg_Playwright_WebDriver_Client.Button;
using Bg_Playwright_WebDriver_Client.Input;
using Bg_Playwright_WebDriver_Client.Playwright;

namespace Bg_PageObjects.Login;

public class LoginPage : PageObject<LoginPage>
{
    public readonly PlaywrightClient _driver;
    public InputComponent UsernameInput { get; }
    public InputComponent PasswordInput { get; }
    public ButtonComponent LoginButton { get; }

    public LoginPage(
        PlaywrightClient driver,
        WebElementFactory factory
    ) : base(driver, factory)
    {
        _driver = driver;
        UsernameInput = Factory.CreateInputElement("username").AsComponent();
        PasswordInput = Factory.CreateInputElement("password").AsComponent();
        LoginButton = Factory.CreateButtonElement("login-button").AsComponent();
    }    

    public LoginPage Login(string email, string password)
    {
        UsernameInput.WaitForInputToBeVisible()
            .Clear()
            .Value(email);
        PasswordInput.WaitForInputToBeVisible()
            .Clear()
            .Value(password);
        LoginButton.WaitToBeInteractable()
            .Click();

        return this;
    } 
}
