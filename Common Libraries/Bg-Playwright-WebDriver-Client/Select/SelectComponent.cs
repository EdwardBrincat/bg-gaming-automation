using Bg_Playwright_WebDriver_Client.Button;
using Bg_Playwright_WebDriver_Client.Playwright;
using Bg_Playwright_WebDriver_Client.SiderBarLink;
using Microsoft.Playwright;
using OpenQA.Selenium;

namespace Bg_Playwright_WebDriver_Client.Select;

public class SelectComponent : IComponent
{
    private readonly Locator _selector;
    private readonly Locator _selectedItem;
    private readonly PlaywrightClient _driver;
    private readonly SelectElementQueryBuilder _selectElementQuery;

    public SelectComponent(
        PlaywrightClient driver,
        SelectElementQueryBuilder selectElementQuery
    )
    {
        _driver = driver;
        _selectElementQuery = selectElementQuery;
        _selector = selectElementQuery.Build();
        _selectedItem = selectElementQuery.GetSelectedElement().Build();
    }

    public SelectComponent WaitToBeInteractable()
    {
        _driver.WaitForElementToBeInteractable(_selector);
        return this;
    }

    public SelectComponent WaitToNotBeInteractable()
    {
        _driver.WaitForElementToNotBeInteractable(_selector);
        return this;
    }

    public string Text()
        => _driver.WaitForElementToBeVisible(_selectedItem)
            .GetAttribute(_selectedItem, "innerText");

    public SelectComponent Open()
    {
        _driver.WaitForElementToBeInteractable(_selector)
            .Click(_selector);

        return this;
    }

    public SelectComponent Close()
    {
        _driver.SendKeys(Keys.Escape);
        return this;
    }

    public SelectComponent Select(string value)
    {
        _driver.WaitForElementToBeInteractable(_selector);

        Open();
        var selectedOption = _selectElementQuery.GetOptionElement(value).Build();
        _driver.WaitForElementToBeInteractable(selectedOption)
            .Click(selectedOption);
        return this;
    }
}
