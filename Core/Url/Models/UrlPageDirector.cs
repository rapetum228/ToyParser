namespace ToyParser.Core.Url
{
    public class UrlPageDirector : IUrlDirector<int>
    {
        private readonly IUrlBuilder _urlBuilder;

        public UrlPageDirector(IUrlBuilder urlBuilder)
        {
            _urlBuilder = urlBuilder;
        }

        public string Build(int numberPage)
        {
            return _urlBuilder.BuildNumberPageLink(numberPage).GetUrl().ToString();
        }
    }
}
