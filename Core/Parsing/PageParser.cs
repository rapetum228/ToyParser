using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    public class PageParser : AbstractParser<IEnumerable<IElement>>
    {

        public override Func<IHtmlDocument, IEnumerable<IElement>> Parse => ParsePage;

        public IEnumerable<IElement> ParsePage(IHtmlDocument htmlDocument)
        {
            var items = htmlDocument
                .QuerySelectorAll("a")
                .Where(item => item.ClassName != null && item.ClassName.Contains("d-block p-1 product-name gtm-click"));
            if (items is null || items.Count() == 0)
            {
                throw new Exception("Товары не спарсены. Попробуйте запустить позже");
            }

            return items;
        }
    }
}
