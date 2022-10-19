using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ToyParser.Core.Data;
using ToyParser.Core.Documents;
using ToyParser.Core.Parsing.ToyProperties;
using ToyParser.Core.Url;

namespace ToyParser.Core.Parsing
{
    internal class ParserHelper
    {
        private readonly IUrlBuilder _urlBuilder;
        private readonly IUrlDirector<string> _urlToyDirector;
        private readonly DocumentCreator<string> _toyDocumentCreator;
        private readonly AbstractParser<IEnumerable<IElement>> _parser;

        public ParserHelper(HttpClient httpClient)
        {
            _urlBuilder = new UrlBuilder();
            _urlToyDirector = new UrlToyDirector(_urlBuilder);
            _toyDocumentCreator = new DocumentCreator<string>(_urlToyDirector, httpClient);
            _parser = new PageParser();
        }


        public async Task<IEnumerable<ToyInformation>> ParsePageAsync(IHtmlDocument document, int numberPage)
        {
            var list = new List<ToyInformation>();
            var items = _parser.Parse?.Invoke(document);

            foreach (var item in items)
            {
                var toyUrl = item.GetAttribute("href");
                var toyDocument = await _toyDocumentCreator.GetDocumentForParseAsync(toyUrl);

                var toy = GetToyInformation(toyDocument);
                toy.ProductUrl = toyUrl;
                toy.PageNumber = numberPage;
                list.Add(toy);
            }

            return list;
        }

        private ToyInformation GetToyInformation(IHtmlDocument document)
        {

            var productName = new ToyNameParser().Parse.Invoke(document);
            var breadCrumb = new BreadcrumbParser().Parse.Invoke(document);
            var available = new AvailableParse().Parse.Invoke(document);
            var oldPrice = new OldPriceParser().Parse.Invoke(document);
            var currentPrice = new CurrentPriceParser().Parse.Invoke(document);
            var imageUrl = new ImageUrlParse().Parse.Invoke(document);
            var region = new RegionNameParser().Parse.Invoke(document);

            return new ToyInformation()
            {
                ProductName = productName,
                Breadcrumbs = breadCrumb,
                IsAvailable = available,
                OldPrice = oldPrice,
                CurrentPrice = currentPrice,
                ImageUrl = imageUrl,
                RegionName = region,
            };
        }

    }
}
