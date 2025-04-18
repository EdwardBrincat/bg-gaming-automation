using Bg_Playwright_WebDriver_Client.Playwright;

namespace Bg_Playwright_WebDriver_Client.Text;

public class TextComponent : IComponent
{
	private readonly PlaywrightClient _driver;
	private readonly TextElementQueryBuilder _textElementQuery;
	private readonly Locator _text;

	public TextComponent(
        PlaywrightClient driver,
		TextElementQueryBuilder textElementQuery
	)
	{
		_driver = driver;
		_textElementQuery = textElementQuery;
		_text = textElementQuery.Build();
	}

	public TextComponent WaitToBeVisible()
	{
		_driver.WaitForElementToBeVisible(_text);
		return this;
	}

	public TextComponent WaitToBeNotVisible()
	{
		_driver.WaitForElementNotToBeVisible(_text);
		return this;
	}	

	public string GetText()
		=> _driver.GetText(_text);

	public string GetInnerText()
		=> _driver.GetAttribute(_text, "innerText");
	
	public string GetAttributeValue(string attributeName)
		=> _driver.GetAttribute(_text, attributeName);
}