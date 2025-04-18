namespace Bg_Playwright_WebDriver_Client.Text;

public class TextElementQueryBuilder : WebElementQueryBuilder<TextComponent>
{
	public TextElementQueryBuilder()
	{
	}

	public TextElementQueryBuilder(WebElementQueryBuilder parent = null) : base(parent)
	{
	}

	public TextElementQueryBuilder(IServiceProvider serviceProvider, string dataTestId) : base(serviceProvider)
	{
		WithDataTestId(dataTestId);
	}

	public TextElementQueryBuilder(IServiceProvider serviceProvider, string childAttributeName, string childAttributeValue) : base(serviceProvider)
	{
		WithChildAttributeContains(childAttributeName, childAttributeValue);
	}
}