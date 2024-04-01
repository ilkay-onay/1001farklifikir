using Microsoft.AspNetCore.Html;

namespace farkli1001fikir.Models
{
public static class CustomHtmlHelper
{
    public static IHtmlContent CustomMethod()
    {
        return new HtmlString("<p>Bu bir custom html helper kullanımıdır.</p>");
    }
}

}