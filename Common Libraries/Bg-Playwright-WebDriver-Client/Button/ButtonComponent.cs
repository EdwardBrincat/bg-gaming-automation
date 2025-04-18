using Bg_Playwright_WebDriver_Client.Playwright;

namespace Bg_Playwright_WebDriver_Client.Button;

public class ButtonComponent : IComponent
{
	private readonly Locator _button;
	private readonly PlaywrightClient _driver;

	public ButtonComponent(
        PlaywrightClient driver,
		ButtonElementQueryBuilder buttonElementQuery
	)
	{
		_driver = driver;
		_button = buttonElementQuery.Build();
	}

	public string GetSelector()
		=> _button.Criteria;

	public ButtonComponent WaitToBeInteractable()
	{
		_driver.WaitForElementToBeInteractable(_button);
		return this;
	}

	public ButtonComponent WaitToNotBeInteractable()
	{
		_driver.WaitForElementToNotBeInteractable(_button);
		return this;
	}

	public ButtonComponent WaitToBeVisible()
	{
		_driver.WaitForElementToBeVisible(_button);
		return this;
	}

    public ButtonComponent WaitNotToBeVisible()
    {
        _driver.WaitForElementNotToBeVisible(_button);
        return this;
    }

    public ButtonComponent Click()
	{
		_driver.Click(_button);
		return this;
	}
}