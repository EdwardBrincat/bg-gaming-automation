using Bg_Playwright_WebDriver_Client.SiderBarLink;

namespace Bg_Playwright_WebDriver_Client.Select;

public class SelectElementQueryBuilder : WebElementQueryBuilder<SelectComponent>
{
    public SelectElementQueryBuilder()
    {
    }

    public SelectElementQueryBuilder(WebElementQueryBuilder? parent = null) : base(parent)
    {
    }

    public SelectElementQueryBuilder(IServiceProvider serviceProvider, string dataTestId) : base(serviceProvider)
    {
        WithDataTestId(dataTestId);
    }

    public SelectElementQueryBuilder(IServiceProvider serviceProvider, string childAttributeName, string childAttributeValue) : base(
        serviceProvider)
    {
        WithChildAttributeContains(childAttributeName, childAttributeValue);
    }

    public WebElementQueryBuilder GetOptionElement()
        => CreateChild<SelectElementQueryBuilder>().WithOption();

    public WebElementQueryBuilder GetSelectedElement()
        => WithDataTestId("active-option");

    public WebElementQueryBuilder GetOptionElement(string value)
        => WithChildAttributeContains("value", value);


}
