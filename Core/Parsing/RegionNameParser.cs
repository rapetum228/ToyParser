using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    public class RegionNameParser : AbstractParser<string>
    {
        public override Func<IHtmlDocument, string> Parse => base.Parse;

        //private string RegionNameParse(IHtmlDocument htmlDocument)
        //{
        //    var items = htmlDocument
        //        .QuerySelectorAll("div")
        //        .Where(item => item.ClassName != null && item.ClassName.Equals("old-price"));
        //    foreach (IHtmlElement item in items)
        //    {
        //        item.DoClick();
        //    }
        //}
    }
}
