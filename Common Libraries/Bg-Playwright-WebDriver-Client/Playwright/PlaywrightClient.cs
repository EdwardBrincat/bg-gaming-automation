using Bg_Core.Exceptions;
using Microsoft.Playwright;
using Polly;
using Polly.Retry;
using System.Text.RegularExpressions;

namespace Bg_Playwright_WebDriver_Client.Playwright;

public class PlaywrightClient
{    
    private readonly Lazy<IPage> _lazyPage;
    private readonly IPageProvider _pageProvider;
    private IPage? Driver { get; set; }

    public PlaywrightClient(Lazy<IPage> driver, IPageProvider pageProvider)
    {
        _lazyPage = driver;
        _pageProvider = pageProvider;

        Driver = _lazyPage.Value;
        pageProvider.SetPage(Driver);
    }

    public void Dispose()
    {
        if (_lazyPage.IsValueCreated)
            Driver?.CloseAsync().GetAwaiter().GetResult();
    }

    public string GetUrl() => Driver?.Url;

    public Task Open(string url)
    {
        try
        {
            Driver?.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.Load }).GetAwaiter().GetResult();

            Console.WriteLine($"Current URL: {Driver.Url}");
            return Task.CompletedTask;
        }
        catch (PlaywrightException e)
        {
            throw HandleFailureException($"Failed to open url[{url}] due to [{e.Message}]");
        }
    }

    public PlaywrightClient WaitForPageToLoad()
    {
        Driver?.WaitForLoadStateAsync(LoadState.DOMContentLoaded).GetAwaiter().GetResult();
        return this;
    }

    public PlaywrightClient WaitForElementToBeInteractable(Locator element)
    {
        try
        {
            Driver?.Locator(element.Criteria).First.WaitForAsync(
                new LocatorWaitForOptions { State = WaitForSelectorState.Attached | WaitForSelectorState.Visible })
            .GetAwaiter()
            .GetResult();
            return this;
        }
        catch (Exception e)
        {
            throw HandleFailureException($"Element failed to be interactable due to [{e.Message}].");
        }
    }

    public PlaywrightClient WaitForElementToNotBeInteractable(Locator element)
    {
        try
        {
            Driver?.Locator(element.Criteria).First.IsDisabledAsync().GetAwaiter().GetResult();
            return this;
        }
        catch (Exception e)
        {
            throw HandleFailureException($"Element failed not to be interactable due to [{e.Message}].");
        }
    }

    public PlaywrightClient WaitForElementToBeVisible(Locator element)
    {
        try
        {
            Driver?.Locator(element.Criteria).First.WaitForAsync(
                new LocatorWaitForOptions { State = WaitForSelectorState.Attached | WaitForSelectorState.Visible })
            .GetAwaiter()
            .GetResult();

            return this;
        }
        catch (Exception e)
        {
            throw HandleFailureException($"Element failed to be visible due to [{e.Message}].");
        }
    }

    public PlaywrightClient WaitForElementNotToBeVisible(Locator element)
    {
        try
        {
            Driver?.Locator(element.Criteria)
                .First
                .WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden | WaitForSelectorState.Detached })
                .GetAwaiter()
                .GetResult();
            return this;
        }
        catch (Exception e)
        {            
            throw HandleFailureException($"[{element}] was still visible due to [{e.Message}]");
        }
    }

    public PlaywrightClient Click(Locator element)
    {
        try
        {
            Driver?.Locator(element.Criteria).First.ClickAsync().GetAwaiter().GetResult();
            return this;
        }
        catch (Exception e)
        {
            throw HandleFailureException($"Failed to click element [{element}] due to [{e.Message}].");
        }
    }

    public PlaywrightClient Clear(Locator element)
    {
        try
        {
            Driver?.Locator(element.Criteria).ClearAsync().GetAwaiter().GetResult();
            return this;
        }
        catch (PlaywrightException e)
        {
            throw HandleFailureException($"Failed to clear[{element}] due to [{e.Message}]");
        }
    }

    public PlaywrightClient Input(Locator element, string text)
    {
        try
        {
            Driver?.Locator(element.Criteria).FillAsync(text).GetAwaiter().GetResult();
            return this;
        }
        catch (PlaywrightException e)
        {
            throw HandleFailureException($"Failed to Input [{text}] into [{element}] due to [{e.Message}]");
        }
    }

    public string GetAttribute(Locator element, string attribute)
    {
        try
        {
            var value = Driver?.Locator(element.Criteria).GetAttributeAsync(attribute).GetAwaiter().GetResult();
            return value;
        }
        catch (PlaywrightException e)
        {
            throw HandleFailureException($"Failed to get attribute [{attribute}] from element [${element}] due to [{e.Message}]");
        }
    }

    public string GetText(Locator element) 
        => Driver?.Locator(element.Criteria).First.InnerTextAsync().GetAwaiter().GetResult();

    public async Task<IList<ILocator>> GetAllPlaywrightElements(Locator element)
    {
        try
        {
            var elements = await Driver?.Locator(element.Criteria).AllAsync();
            return elements.ToList();
        }
        catch (Exception e)
        {
            throw HandleFailureException($"Failed getting all web elements of type [{element}] as ILocator due to [{e.Message}].");
        }
    }

    public PlaywrightClient SendKeys(string keyCode)
    {
        try
        {
            Driver?.Keyboard.PressAsync("Escape").GetAwaiter().GetResult();
            return this;
        }
        catch (Exception e)
        {
            throw HandleFailureException($"Failed to press [{keyCode}] due to [{e.Message}].");
        }
    }

    public TestStepFailureException HandleFailureException(string message)
    {        
        Driver?.CloseAsync();
        throw new TestStepFailureException(message);
    }
}
