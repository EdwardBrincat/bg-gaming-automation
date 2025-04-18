namespace Bg_Playwright_WebDriver_Client.SiderBarLink;

public class SideBarLinkElementQueryBuilder : WebElementQueryBuilder<SideBarLinkComponent>
{
	public SideBarLinkElementQueryBuilder()
	{
	}

	public SideBarLinkElementQueryBuilder(WebElementQueryBuilder? parent = null) : base(parent)
	{
	}

	public SideBarLinkElementQueryBuilder(IServiceProvider serviceProvider, string dataTestId) : base(serviceProvider)
	{
        WithDataTestId(dataTestId);
	}

	public SideBarLinkElementQueryBuilder(IServiceProvider serviceProvider, string childAttributeName, string childAttributeValue) : base(
		serviceProvider)
	{
		WithChildAttributeContains(childAttributeName, childAttributeValue);
	}	
}