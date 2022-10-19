using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    internal class CurrentPriceParser : AbstractParser<string>
    {
        public override Func<IHtmlDocument, string> Parse => ParseCurrentPrice;

        private string ParseCurrentPrice(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument
                .QuerySelector("span.price");
                /*.FirstOrDefault(item => item.ClassName != null && item.ClassName.Equals("price"));*/
            if (item is null)
            {
                Console.WriteLine("Цена не найдена");
                return "Цена не найдена";
            }

            var price = item.TextContent;
            return price;
        }
    }
}
