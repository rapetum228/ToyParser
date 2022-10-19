using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyParser.Core
{
    public static class RegionDataSetter
    {

        public static void RegionNameParse(IDocument htmlDocument)
        {
            var items = htmlDocument
                .QuerySelectorAll("ul.column li a");
                /*.FirstOrDefault(item => item.ClassName != null && item.ClassName.Equals("region-links"))*/;

            ((IHtmlElement)items[4]).DoClick();
            Thread.Sleep(5000);
            //foreach (var item in items)
            //{
            //    Console.WriteLine(item.TextContent);
            //}
        }
    }
}
