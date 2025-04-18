namespace Bg_Playwright_WebDriver_Client.Button;

public class ButtonElementQueryBuilder : WebElementQueryBuilder<ButtonComponent>
{
	public ButtonElementQueryBuilder()
	{
	}

	public ButtonElementQueryBuilder(WebElementQueryBuilder? parent = null) : base(parent)
	{
	}

	public ButtonElementQueryBuilder(IServiceProvider serviceProvider, string dataTestId) : base(serviceProvider)
	{
        WithDataTestId(dataTestId);
	}

	public ButtonElementQueryBuilder(IServiceProvider serviceProvider, string childAttributeName, string childAttributeValue) : base(
		serviceProvider)
	{
		WithChildAttributeContains(childAttributeName, childAttributeValue);
	}	
}