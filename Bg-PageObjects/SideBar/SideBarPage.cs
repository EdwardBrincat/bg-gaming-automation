using Bg_Playwright_WebDriver_Client;
using Bg_Playwright_WebDriver_Client.Button;
using Bg_Playwright_WebDriver_Client.Playwright;
using Bg_Playwright_WebDriver_Client.SiderBarLink;

namespace Bg_PageObjects.Sidebar;

public class SideBarPage : PageObject<SideBarPage>
{
    public readonly PlaywrightClient _driver;
    
    public ButtonComponent OpenSideBarButton { get; }
    public ButtonComponent CloseSideBarButton { get; }
    public SideBarLinkComponent AllItemsButton { get; }
    public SideBarLinkComponent AboutButton { get; }
    public SideBarLinkComponent LogoutButton { get; }
    public SideBarLinkComponent ResetAppStateButton { get; }

    public SideBarPage(
        PlaywrightClient driver,
        WebElementFactory factory
    ) : base(driver, factory)
    {
        _driver = driver;
        OpenSideBarButton = Factory.CreateButtonElement("id", "react-burger-menu-btn").AsComponent();
        CloseSideBarButton = Factory.CreateButtonElement("id", "react-burger-cross-btn").AsComponent();
        AllItemsButton = Factory.CreateSideBarLinkElement("inventory-sidebar-link").AsComponent();
        AboutButton = Factory.CreateSideBarLinkElement("about-sidebar-link").AsComponent();
        LogoutButton = Factory.CreateSideBarLinkElement("logout-sidebar-link").AsComponent();
        ResetAppStateButton = Factory.CreateSideBarLinkElement("reset-sidebar-link").AsComponent();
    }

    public SideBarPage OpenSideBar()
    {
        OpenSideBarButton.WaitToBeInteractable()
            .Click();
        return this;
    }

    public SideBarPage CloseSideBar()
    {
        CloseSideBarButton.WaitToBeInteractable()
            .Click();
        return this;
    }

    public SideBarPage ClickAllItemsButton()
    {
        AllItemsButton.WaitToBeInteractable()
            .Click();
        return this;
    }

    public SideBarPage ClickAboutButton()
    {
        AboutButton.WaitToBeInteractable()
            .Click();
        return this;
    }

    public SideBarPage ClickLogoutButton()
    {
        LogoutButton.WaitToBeInteractable()
            .Click();
        return this;
    }

    public SideBarPage ClickResetAppStateButton()
    {
        ResetAppStateButton.WaitToBeInteractable()
            .Click();
        return this;
    }

    public SideBarPage WaitForAllItemsToBeVisible()
    {
        AllItemsButton.WaitToBeVisible();
        return this;
    }

    public SideBarPage WaitForAboutToBeVisible()
    {
        AboutButton.WaitToBeVisible();
        return this;
    }

    public SideBarPage WaitForLogoutToBeVisible()
    {
        LogoutButton.WaitToBeVisible();
        return this;
    }

    public SideBarPage WaitForResetAppStateToBeVisible()
    {
        ResetAppStateButton.WaitToBeVisible();
        return this;
    }

}
