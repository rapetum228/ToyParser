using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ToyParser.Core.Documents;
using ToyParser.Core.Url;

namespace ToyParser.Core.Documents
{
    public class DocumentCreator<T>
    {
        private IUrlDirector<T> _urlDirector;
        private readonly HttpClient _httpClient;
        public DocumentCreator(IUrlDirector<T> urlDirector, HttpClient httpClient)
        {
            _urlDirector = urlDirector;
            _httpClient = httpClient;
        }

        public async Task<IHtmlDocument> GetDocumentForParseAsync(T urlParameter)
        {
            var currentUrl = _urlDirector.Build(urlParameter);
            var htmlLoader = new HtmLoader(_httpClient);
            var source = await htmlLoader.GetSource(currentUrl);

            var domParser = new HtmlParser();
            return await domParser.ParseDocumentAsync(source);
        }

    }
}
