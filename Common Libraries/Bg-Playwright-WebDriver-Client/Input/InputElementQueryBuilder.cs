namespace Bg_Playwright_WebDriver_Client.Input;

public class InputElementQueryBuilder : WebElementQueryBuilder<InputComponent>
{
	public InputElementQueryBuilder()
	{
	}

	public InputElementQueryBuilder(WebElementQueryBuilder parent = null) : base(parent)
	{
	}

	public InputElementQueryBuilder(IServiceProvider serviceProvider, string dataTestId) : base(serviceProvider)
	{
		WithDataTestId(dataTestId);
	}

	public InputElementQueryBuilder(IServiceProvider serviceProvider, string childAttributeName, string childAttributeValue) : base(
		serviceProvider)
	{
		WithChildAttributeContains(childAttributeName, childAttributeValue);
	}	
}