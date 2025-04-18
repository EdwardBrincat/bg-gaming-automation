using Bg_Playwright_WebDriver_Client.Playwright;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace Bg_Playwright_WebDriver_Client;

public class WebElementQueryBuilder<TComponent> : WebElementQueryBuilder where TComponent : IComponent
{
	private readonly IServiceProvider _serviceProvider;

	public WebElementQueryBuilder(WebElementQueryBuilder parent = null) : base(parent)
	{
	}

	public WebElementQueryBuilder(
		IServiceProvider serviceProvider,
		WebElementQueryBuilder parent = null
	) : base(parent)
	{
		_serviceProvider = serviceProvider;
	}

	public TComponent AsComponent() => ActivatorUtilities.CreateInstance<TComponent>(_serviceProvider, this);

	public T CreateChild<T>() where T : WebElementQueryBuilder, new()
	{
		Query = Parent?.Query + Query;
		return ActivatorUtilities.CreateInstance<T>(_serviceProvider, this);
	}
}

public class WebElementQueryBuilder
{
	public WebElementQueryBuilder(WebElementQueryBuilder parent = null)
	{
		Parent = parent;
	}

	public WebElementQueryBuilder Parent { get; }

	public string Query { get; set; }

	public WebElementQueryBuilder WithCss(string query)
	{
		Query += query;
		return this;
	}

    public WebElementQueryBuilder WithAttribute(string attribute, string value, string @operator)
    {
        if (!String.IsNullOrEmpty(Query))
            Query = Query.TrimEnd();

        Query += $"[{attribute}{@operator}\"{value}\"]";
        return this;
    }

    public WebElementQueryBuilder WithChildAttribute(string attribute, string value, string @operator)
    {
        if (!String.IsNullOrEmpty(Query))
            Query = Query.TrimEnd();

        Query += $" [{attribute}{@operator}\"{value}\"]";
        return this;
    }

    public WebElementQueryBuilder WithNthChild(int index)
    {
        if (!String.IsNullOrEmpty(Query))
            Query = Query.TrimEnd();

        Query += $":nth-of-type({index})";
        return this;
    }

    public WebElementQueryBuilder WithAttributeEqual(string attribute, string value)
		=> WithAttribute(attribute, value, "=");		

	public WebElementQueryBuilder WithChildAttributeContains(string attribute, string value)
		=> WithChildAttribute(attribute, value, "*=");
	
    public WebElementQueryBuilder WithDataTestId(string dataTestId) => WithAttributeEqual("data-test", dataTestId);

	public Locator Build()
		=> new Locator
		{
			Criteria = Parent?.Query + Query
		};

    public WebElementQueryBuilder WithElement(string element)
    {
        Query += $" {element}";
        return this;
    }

    public WebElementQueryBuilder WithOption() => WithElement(WebElementTagName.Option);
}