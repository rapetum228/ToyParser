using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    internal class ToyNameParser : AbstractParser<string>
    {

        public Func<IHtmlDocument, string> Parse => ParseName;

        private string ParseName(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument
                .QuerySelector("h1.detail-name");
                //.FirstOrDefault(item => item.ClassName != null && item.ClassName.Contains("detail-name"));
            if (item is null)
            {
                Console.WriteLine("Название не найдено");
                return "Название не найдено";
            }
            return item.TextContent;
        }
    }
}
