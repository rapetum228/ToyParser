namespace ToyParser.Core.Url
{
    public interface IUrlDirector<T>
    {
        public string Build(T parameter);
    }
}
