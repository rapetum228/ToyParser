using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    internal class ImageUrlParse : AbstractParser<string>
    {
        public override Func<IHtmlDocument, string> Parse => ParseImageUrl;

        public string ParseImageUrl(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument
                .QuerySelector("div.card-slider-nav img.img-fluid");
                //.FirstOrDefault(item => item.ClassName != null && item.ClassName.Contains("img-fluid"));
            if (item is null)
            {
                Console.WriteLine("Url картинки не найдено");
                return "Url картинки не найдено";
            }

            return item.GetAttribute("src").ToString();
        }
    }
}
