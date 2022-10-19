namespace ToyParser.Core.Url
{
    public interface IUrlBuilder
    {
        IUrlBuilder BuildNumberPageLink(int numberPage);
        IUrlBuilder BuildToyLink(string toyLink);
        MyUrl GetUrl();

    }
}
