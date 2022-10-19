using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    internal class CurrentPriceParser : AbstractParser<string>
    {
        public override Func<IHtmlDocument, string> Parse => ParseCurrentPrice;

        private string ParseCurrentPrice(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument.QuerySelector("span.price");

            if (item is null)
            {
                return "Цена не найдена";
            }

            var price = item.TextContent;
            return price;
        }
    }
}
