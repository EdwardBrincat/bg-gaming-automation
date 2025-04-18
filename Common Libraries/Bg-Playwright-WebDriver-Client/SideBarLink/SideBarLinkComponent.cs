using Bg_Playwright_WebDriver_Client.Playwright;

namespace Bg_Playwright_WebDriver_Client.SiderBarLink;

public class SideBarLinkComponent : IComponent
{
	private readonly Locator _sideBarLink;
	private readonly PlaywrightClient _driver;

	public SideBarLinkComponent(
        PlaywrightClient driver,
		SideBarLinkElementQueryBuilder sideBarLinkElementQuery
	)
	{
		_driver = driver;
        _sideBarLink = sideBarLinkElementQuery.Build();
	}

	public string GetSelector()
		=> _sideBarLink.Criteria;

	public SideBarLinkComponent WaitToBeInteractable()
	{
		_driver.WaitForElementToBeInteractable(_sideBarLink);
		return this;
	}

	public SideBarLinkComponent WaitToNotBeInteractable()
	{
		_driver.WaitForElementToNotBeInteractable(_sideBarLink);
		return this;
	}

	public SideBarLinkComponent WaitToBeVisible()
	{
		_driver.WaitForElementToBeVisible(_sideBarLink);
		return this;
	}

    public SideBarLinkComponent WaitNotToBeVisible()
    {
        _driver.WaitForElementNotToBeVisible(_sideBarLink);
        return this;
    }

    public SideBarLinkComponent Click()
	{
		_driver.Click(_sideBarLink);
		return this;
	}
}