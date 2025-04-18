using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bg_Playwright_WebDriver_Client.Playwright;

public class Locator
{
    public string Criteria { get; set; }

    public static Locator ClassName(string className)
    {
        if (className == null)
        {
            throw new ArgumentNullException("className", "Cannot find elements when the class name expression is null.");
        }

        return new Locator
        {
            Criteria = $".{className}"
        }; 
    }

    public static Locator DataTestId(string dataTestid)
    {
        if (dataTestid == null)
        {
            throw new ArgumentNullException("dataTestid", "Cannot find elements when the data test id expression is null.");
        }

        return new Locator
        {
            Criteria = $"[data-test='{dataTestid}']"
        };
    }

}
