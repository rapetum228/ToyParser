using AngleSharp.Html.Dom;

namespace ToyParser.Core.Parsing
{
    public abstract class AbstractParser<T>
    {

        public virtual Func<IHtmlDocument, T> Parse { get; }

    }
}
