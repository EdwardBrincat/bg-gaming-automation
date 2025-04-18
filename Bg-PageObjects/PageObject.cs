using Bg_Core.Exceptions;
using Bg_Playwright_WebDriver_Client;
using Bg_Playwright_WebDriver_Client.Playwright;
using Microsoft.Playwright;
using Polly;
using Polly.Retry;
using System.Collections.ObjectModel;

namespace Bg_PageObjects;

public interface IPageObject<out TPageObject>
{
	void Open(string baseUrl);
}

public class PageObject<TPageObject> : IPageObject<TPageObject>
	where TPageObject : IPageObject<TPageObject>
{
	private readonly TPageObject _this;

	protected readonly RetryPolicy ConfigRetryPolicy;
	protected readonly PlaywrightClient Driver;
	protected readonly WebElementFactory Factory;

	protected PageObject(
        PlaywrightClient driver,
		WebElementFactory factory
	)
	{
		Factory = factory;
		Driver = driver;
		_this = (TPageObject)(object)this;

		ConfigRetryPolicy = Policy
			.Handle<TestConfigurationFailureException>()
			.WaitAndRetry(5, x => TimeSpan.FromSeconds(30));
	}

	public void Open(string baseUrl)
	=>	Driver.Open(baseUrl);

	public TPageObject Do(Action<TPageObject> action)
	{
		action(_this);
		return _this;
	}

	public string GetUrl() => Driver.GetUrl();	

	public TPageObject FailTest(string message)
	{
		Driver.HandleFailureException(message);
		return _this;
	}	
	
	public string GetSystemUrl()
		=> Uri.UnescapeDataString(Driver.GetUrl());

	public TPageObject WaitForPageToLoad()
	{
		Driver.WaitForPageToLoad();
		return _this;
	}	
}
