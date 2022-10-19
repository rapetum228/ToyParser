using AngleSharp.Html.Dom;
using System.Text;

namespace ToyParser.Core.Parsing
{
    internal class BreadcrumbParser : AbstractParser<string>
    {
        public Func<IHtmlDocument, string> Parse => ParseBreadcrumb;

        private string ParseBreadcrumb(IHtmlDocument htmlDocument)
        {
            var sb = new StringBuilder();
            var items = htmlDocument
                .QuerySelectorAll("a")
                .Where(item => item.ClassName != null && item.ClassName.Contains("breadcrumb-item hide-mobile"));

            if (items is null || items.Count() == 0)
            {
                return "Хлебные крошки не найдены";
            }

            foreach (var item in items)
            {
                sb.Append(item.GetAttribute("title")).Append(" > ");
            }
            return sb.ToString();
        }
    }
}
