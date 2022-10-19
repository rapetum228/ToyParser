namespace ToyParser.Core.Url
{
    internal class UrlToyDirector : IUrlDirector<string>
    {
        private readonly IUrlBuilder _urlBuilder;

        public UrlToyDirector(IUrlBuilder urlBuilder)
        {
            _urlBuilder = urlBuilder;
        }

        public string Build(string hrefToy)
        {
            return _urlBuilder.BuildToyLink(hrefToy).GetUrl().ToString();
        }
    }
}
