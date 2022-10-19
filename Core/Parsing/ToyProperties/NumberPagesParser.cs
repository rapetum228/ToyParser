using AngleSharp.Html.Dom;
using AngleSharp.Text;

namespace ToyParser.Core.Parsing.ToyProperties
{
    internal class NumberPagesParser : AbstractParser<int>
    {
        public override Func<IHtmlDocument, int> Parse => ParseNumberPages;

        public int ParseNumberPages(IHtmlDocument htmlDocument)
        {
            var items = htmlDocument
               .QuerySelectorAll("li")
                .Where(item => item.ClassName != null && item.ClassName.Equals("page-item"));

            if (items is null || items.Count() == 0)
            {
                throw new Exception("Номера страниц не загрузились");
            }
            var arrayItems = items.ToArray();
            var numbereLastPage = arrayItems[arrayItems.Length - 2].TextContent.ToString();
            int res = 0;
            var result = numbereLastPage.ToInteger(res);
            return result;
        }
    }
}
