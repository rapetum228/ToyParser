using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing.ToyProperties
{
    public class RegionNameParser : AbstractParser<string>
    {
        public override Func<IHtmlDocument, string> Parse => RegionNameParse;

        private string RegionNameParse(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument.QuerySelector("div[class='col-12 select-city-link'] a");

            if (item is null)
            {
                return "Город не найден";
            }
            var result = item.TextContent.Trim();

            return result;
        }
    }
}
