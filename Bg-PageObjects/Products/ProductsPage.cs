using Bg_PageObjects.Login;
using Bg_Playwright_WebDriver_Client;
using Bg_Playwright_WebDriver_Client.Button;
using Bg_Playwright_WebDriver_Client.Input;
using Bg_Playwright_WebDriver_Client.Playwright;
using Bg_Playwright_WebDriver_Client.Select;
using Bg_Playwright_WebDriver_Client.Text;

namespace Bg_PageObjects.Products;

class ProductsPage : PageObject<ProductsPage>
{
    public readonly PlaywrightClient _driver;   
    public ButtonComponent BackPackAddCartButton { get; }
    public ButtonComponent BackPackRemoveCartButton { get; }
    public ButtonComponent BikeLightAddCartButton { get; }
    public ButtonComponent BikeLightRemoveCartButton { get; }
    public ButtonComponent BoltTShirtAddCartButton { get; }
    public ButtonComponent BoltTShirtRemoveCartButton { get; }
    public ButtonComponent FleeceJacketAddCartButton { get; }
    public ButtonComponent FleeceJacketRemoveCartButton { get; }
    public ButtonComponent OnesieAddCartButton { get; }
    public ButtonComponent OnesieRemoveCartButton { get; }
    public ButtonComponent TestAllTheThingsTShirtAddCartButton { get; }
    public ButtonComponent TestAllTheThingsTShirtRemoveCartButton { get; }
    public TextComponent CartBadge { get; }
    public SelectComponent FilterSelect { get; }

    public ProductsPage(
        PlaywrightClient driver,
        WebElementFactory factory
    ) : base(driver, factory)
    {
        _driver = driver;
        BackPackAddCartButton = Factory.CreateButtonElement("add-to-cart-sauce-labs-backpack").AsComponent();
        BackPackRemoveCartButton = Factory.CreateButtonElement("remove-sauce-labs-backpack").AsComponent();
        BikeLightAddCartButton = Factory.CreateButtonElement("add-to-cart-sauce-labs-bike-light").AsComponent();
        BikeLightRemoveCartButton = Factory.CreateButtonElement("remove-sauce-labs-bike-light").AsComponent();
        BoltTShirtAddCartButton = Factory.CreateButtonElement("add-to-cart-sauce-labs-bolt-t-shirt").AsComponent();
        BoltTShirtRemoveCartButton = Factory.CreateButtonElement("remove-sauce-labs-bolt-t-shirt").AsComponent();
        FleeceJacketAddCartButton = Factory.CreateButtonElement("add-to-cart-sauce-labs-fleece-jacket").AsComponent();
        FleeceJacketRemoveCartButton = Factory.CreateButtonElement("remove-sauce-labs-fleece-jacket").AsComponent();
        OnesieAddCartButton = Factory.CreateButtonElement("add-to-cart-sauce-labs-onesie").AsComponent();
        OnesieRemoveCartButton = Factory.CreateButtonElement("remove-sauce-labs-onesie").AsComponent();
        TestAllTheThingsTShirtAddCartButton = Factory.CreateButtonElement("add-to-cart-test.allthethings()-t-shirt-(red)").AsComponent();
        TestAllTheThingsTShirtRemoveCartButton = Factory.CreateButtonElement("remove-test.allthethings()-t-shirt-(red)").AsComponent();
        CartBadge = Factory.CreateTextElement("shopping-cart-badge").AsComponent();
        FilterSelect = Factory.CreateSelectElement("product_sort_container").AsComponent();
    }

    public ProductsPage ClickBackPackAddCartButton()
    {
        BackPackAddCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickBackPackRemoveCartButton()
    {
        BackPackRemoveCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickBikeLightAddCartButton()
    {
        BikeLightAddCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickBikeLightRemoveCartButton()
    {
        BikeLightRemoveCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickBoltTShirtAddCartButton()
    {
        BoltTShirtAddCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickBoltTShirtRemoveCartButton()
    {
        BoltTShirtRemoveCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickFleeceJacketAddCartButton()
    {
        FleeceJacketAddCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickFleeceJacketRemoveCartButton()
    {
        FleeceJacketRemoveCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickOnesieAddCartButton()
    {
        OnesieAddCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickOnesieRemoveCartButton()
    {
        OnesieRemoveCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickTestAllTheThingsTShirtAddCartButton()
    {
        TestAllTheThingsTShirtAddCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public ProductsPage ClickTestAllTheThingsTShirtRemoveCartButton()
    {
        TestAllTheThingsTShirtRemoveCartButton.WaitToBeInteractable().Click();
        return this;
    }

    public async Task<List<ProductModel>> GetProductDetails()
    {
        var productList = new List<ProductModel>();

        var elements = await _driver.GetAllPlaywrightElements(Locator.DataTestId("inventory-item"));

        foreach (var element in elements)
        {
            var productImage = element.Locator("[class='inventory_item_img']");
            var productImageUrl = await productImage.GetAttributeAsync("src");
            
            var productName = element.Locator("[class='inventory_item_name']");
            var productNameText = await productName.InnerTextAsync();

            var productDescription = element.Locator("[class='inventory_item_desc']");
            var productDescriptionText = await productDescription.InnerTextAsync();

            var productPrice = element.Locator("[class='inventory_item_price']");
            var productPriceText = await productPrice.InnerTextAsync();

            var product = new ProductModel
            {
                ImageUrl = productImageUrl,
                Name = productNameText,
                Description = productDescriptionText,
                Price = productPriceText
            };
            productList.Add(product);
        }

        return productList;
    }

    public string GetCartItemNumber()
        => CartBadge.GetText();

    public ProductsPage SelectFilter(string filter)
    {
        FilterSelect.WaitToBeInteractable().Select(filter);
        return this;
    }

    public string GetSelectedFilter()
        => FilterSelect.Text();
}
