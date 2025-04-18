using Bg_Playwright_WebDriver_Client.Playwright;

namespace Bg_Playwright_WebDriver_Client.Input;

public class InputComponent : IComponent
{
	private readonly PlaywrightClient _driver;
	private readonly Locator _input;

	public InputComponent(
        PlaywrightClient driver,
		InputElementQueryBuilder inputElementQuery
	)
	{
		_driver = driver;
		_input = inputElementQuery.Build();
	}

	public string GetSelector()
		=> _input.Criteria;

    public InputComponent WaitForInputToBeVisible()
    {
        _driver.WaitForElementToBeVisible(_input);
        return this;
    }

    public InputComponent WaitForInputNotToBeVisible()
    {
        _driver.WaitForElementNotToBeVisible(_input);
        return this;
    }

    public InputComponent WaitToBeNotInteractable()
    {
        _driver.WaitForElementToNotBeInteractable(_input);
        return this;
    }

    public InputComponent WaitToBeInteractable()
    {
        _driver.WaitForElementToBeInteractable(_input);
        return this;
    }

    public InputComponent Clear()
	{
		_driver.Clear(_input);
		return this;
	}	

	public InputComponent Value(string value)
	{
		_driver.Input(_input, value);
		return this;
	}

	public string GetValue() 
		=> _driver.WaitForElementToBeVisible(_input).GetAttribute(_input, "value");
}