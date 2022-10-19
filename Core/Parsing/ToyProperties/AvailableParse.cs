using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    internal class AvailableParse : AbstractParser<string>
    {
        public Func<IHtmlDocument, string> Parse => ParseAvailable;

        private string ParseAvailable(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument
                .QuerySelector("span.ok");
            //.FirstOrDefault(item => item.ClassName != null && item.ClassName.Contains("ok"));

            if (item is null)
            {
                return "Нет в наличии";
            }

            return item.TextContent;
        }
    }
}
