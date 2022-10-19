namespace ToyParser.Core.Url
{
    internal class UrlBuilder : IUrlBuilder
    {
        private MyUrl _url;

        public UrlBuilder()
        {
            _url = new MyUrl();
        }


        public IUrlBuilder BuildNumberPageLink(int numberPage)
        {
            _url.NumberPageLink = $"/catalog/boy_transport/?filterseccode%5B0%5D=transport&PAGEN_5={numberPage}";
            _url.ToyLink = string.Empty;
            return this;
        }

        public IUrlBuilder BuildToyLink(string toyLink)
        {
            _url.ToyLink = toyLink;
            _url.NumberPageLink = string.Empty;
            return this;
        }

        public MyUrl GetUrl()
        {
            return _url;
        }
    }
}
