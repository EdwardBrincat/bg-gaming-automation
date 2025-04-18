using Bg_Playwright_WebDriver_Client.BrowserConfigurations;
using Bg_Playwright_WebDriver_Client.Playwright;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;

namespace Bg_Playwright_WebDriver_Client;

public class WebDriverClientFactory
{
	private readonly PlaywrightBrowserConfigurations _playwrightBrowserConfigurations;
	private readonly IServiceProvider _serviceProvider;	
	private IPlaywright _playwrightDriver = null!;

	public WebDriverClientFactory(
		IServiceProvider serviceProvider,
		PlaywrightBrowserConfigurations playwrightBrowserConfigurations
	)
	{
		_serviceProvider = serviceProvider;
		_playwrightBrowserConfigurations = playwrightBrowserConfigurations;		
	}

	public PlaywrightClient Create()
	{
		var attempts = 1;
		IBrowser? browser;

		var lazyDriverPlaywright = new Lazy<IPage>(() => InitPlaywright());
		return ActivatorUtilities.CreateInstance<PlaywrightClient>(_serviceProvider, lazyDriverPlaywright);

		IPage InitPlaywright()
		{
			try
			{						
				_playwrightDriver = Microsoft.Playwright.Playwright.CreateAsync().GetAwaiter().GetResult();

                //For the scope of this test we are using the Chromium browser
                var browser = _playwrightDriver.Chromium.LaunchAsync(_playwrightBrowserConfigurations.GetChromeOptions()).GetAwaiter().GetResult();
				
				var context = browser.NewContextAsync(new BrowserNewContextOptions()
				{
					ViewportSize = new ViewportSize()
					{
						Width = 1920,
						Height = 1080
					}
				}).GetAwaiter().GetResult();

				return context.NewPageAsync().GetAwaiter().GetResult();
			}
			catch (PlaywrightException ex)
			{
				if (attempts == 3)
				{
					StepExecution.Current.IgnoreScenario($"Failed to start web driver instance due to: {ex}");
				}

				attempts++;
				return InitPlaywright();
			}
		}			
		
	}
}