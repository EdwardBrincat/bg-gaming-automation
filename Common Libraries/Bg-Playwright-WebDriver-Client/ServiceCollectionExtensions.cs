using Bg_Playwright_WebDriver_Client.BrowserConfigurations;
using Bg_Playwright_WebDriver_Client.Playwright;
using Microsoft.Extensions.DependencyInjection;

namespace Bg_Playwright_WebDriver_Client;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddWebDriverClient(this IServiceCollection services)
	{
		services.AddSingleton<IPageProvider, PageProvider>();
		services.AddScoped<PlaywrightBrowserConfigurations>();
		services.AddScoped<WebDriverClientFactory>();
		services.AddScoped<WebElementFactory>();	

		return services;
	}
}