using Microsoft.Playwright;
using static Microsoft.Playwright.Playwright;

namespace Bg_Playwright_WebDriver_Client.Playwright;

public interface IPageProvider
{
	IPage GetPage();
	void SetPage(IPage page);
}

public class PageProvider : IPageProvider
{
	public IPage Page = CreateAsync().GetAwaiter().GetResult()
		.Chromium.LaunchAsync().GetAwaiter().GetResult().NewPageAsync().GetAwaiter().GetResult();

	public IPage GetPage() => Page;

	public void SetPage(IPage page) => Page = page;
}