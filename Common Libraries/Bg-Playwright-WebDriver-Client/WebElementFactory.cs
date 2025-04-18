using Microsoft.Extensions.DependencyInjection;
using Bg_Playwright_WebDriver_Client.Button;
using Bg_Playwright_WebDriver_Client.Input;
using Bg_Playwright_WebDriver_Client.Text;
using Bg_Playwright_WebDriver_Client.SiderBarLink;
using Bg_Playwright_WebDriver_Client.Select;


namespace Bg_Playwright_WebDriver_Client;

public class WebElementFactory
{
	
	private readonly IServiceProvider _serviceProvider;

	public WebElementFactory(
		IServiceProvider serviceProvider
	)
	{
		_serviceProvider = serviceProvider;
	}

	public WebElementQueryBuilder CreateElement() => new();

	public ButtonElementQueryBuilder CreateButtonElement(string dataTestId)
		=> ActivatorUtilities.CreateInstance<ButtonElementQueryBuilder>(_serviceProvider, dataTestId);

	public ButtonElementQueryBuilder CreateButtonElement(string childAttributeName, string childAttributeValue)
		=> ActivatorUtilities.CreateInstance<ButtonElementQueryBuilder>(_serviceProvider, childAttributeName, childAttributeValue);

    public InputElementQueryBuilder CreateInputElement(string dataTestId)
        => ActivatorUtilities.CreateInstance<InputElementQueryBuilder>(_serviceProvider, dataTestId);

    public InputElementQueryBuilder CreateInputElement(string childAttributeName, string childAttributeValue)
        => ActivatorUtilities.CreateInstance<InputElementQueryBuilder>(_serviceProvider, childAttributeName, childAttributeValue);

    public TextElementQueryBuilder CreateTextElement(string dataTestId)
        => ActivatorUtilities.CreateInstance<TextElementQueryBuilder>(_serviceProvider, dataTestId);

    public TextElementQueryBuilder CreateTextElement(string childAttributeName, string childAttributeValue)
        => ActivatorUtilities.CreateInstance<TextElementQueryBuilder>(_serviceProvider, childAttributeName, childAttributeValue);

    public SideBarLinkElementQueryBuilder CreateSideBarLinkElement(string dataTestId)
        => ActivatorUtilities.CreateInstance<SideBarLinkElementQueryBuilder>(_serviceProvider, dataTestId);

    public SideBarLinkElementQueryBuilder CreateSideBarLinkElement(string childAttributeName, string childAttributeValue)
        => ActivatorUtilities.CreateInstance<SideBarLinkElementQueryBuilder>(_serviceProvider, childAttributeName, childAttributeValue);

    public SelectElementQueryBuilder CreateSelectElement(string dataTestId)
       => ActivatorUtilities.CreateInstance<SelectElementQueryBuilder>(_serviceProvider, dataTestId);

    public SelectElementQueryBuilder CreateSelectElement(string childAttributeName, string childAttributeValue)
        => ActivatorUtilities.CreateInstance<SelectElementQueryBuilder>(_serviceProvider, childAttributeName, childAttributeValue);
}