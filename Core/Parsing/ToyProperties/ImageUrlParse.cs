using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    internal class ImageUrlParse : AbstractParser<string>
    {
        public override Func<IHtmlDocument, string> Parse => ParseImageUrl;

        public string ParseImageUrl(IHtmlDocument htmlDocument)
        {
            var item = htmlDocument.QuerySelector("div.card-slider-nav img.img-fluid");

            if (item is null)
            {
                return "Url картинки не найдено";
            }

            return item.GetAttribute("src").ToString();
        }
    }
}
