using Microsoft.Playwright;

namespace Bg_Playwright_WebDriver_Client.BrowserConfigurations;

public class PlaywrightBrowserConfigurations
{
	private BrowserTypeLaunchOptions _browserOptions;

	public PlaywrightBrowserConfigurations()
	{
	}

	public BrowserTypeLaunchOptions GetDefaultOptions()
	{
		_browserOptions = new BrowserTypeLaunchOptions();
		_browserOptions.Headless = false; ;

		_browserOptions.Args = new[] 
		{ 
			"--no-sandbox", 
			"--disable-setuid-sandbox", 
			"--privileged", 
			"--disable-extensions", 
			"--ignore-certificate-errors", 
			"--disable-popup-blocking", 
			"--incognito", 
			"--whitelist-ip %*", 
			"--mute-audio", 
			"--disable-site-isolation-trials",
			"--disable-dev-shm-usage",
			"--disable-blink-features=AutomationControlled",
			"--host-resolver-rules=MAP www.googletagmanager.com localhost,MAP cdn.optimizely.com localhost" 
		};
		
		return _browserOptions;
	}

	public BrowserTypeLaunchOptions GetChromeOptions()
	{
		_browserOptions = GetDefaultOptions();
		_browserOptions.Channel = "chrome";
		return _browserOptions;
	}
}