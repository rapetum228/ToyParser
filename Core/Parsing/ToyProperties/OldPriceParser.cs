using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    internal class OldPriceParser : AbstractParser<string>
    {

        public override Func<IHtmlDocument, string> Parse => ParseOldPrice;
        public string ParseOldPrice(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument
                .QuerySelector("span.old-price");
                //.FirstOrDefault(item => item.ClassName != null && item.ClassName.Equals("old-price"));
            if (item is null)
            {
                return "Цена не менялась";
            }
            var price = item.TextContent;
            string.Join("", price.Where(c => char.IsDigit(c)));
            return price;
        }
    }
}
