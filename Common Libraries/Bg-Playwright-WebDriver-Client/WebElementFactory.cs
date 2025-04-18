using Microsoft.Extensions.DependencyInjection;
using Bg_Playwright_WebDriver_Client.Button;
using Bg_Playwright_WebDriver_Client.Input;
using Bg_Playwright_WebDriver_Client.Text;


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

}