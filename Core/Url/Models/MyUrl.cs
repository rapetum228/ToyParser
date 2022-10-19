using System.Text;

namespace ToyParser.Core.Url
{
    public class MyUrl
    {
        private readonly string _baseUrl = "https://www.toy.ru";

        public MyUrl()
        {

        }

        public string NumberPageLink { get; set; }
        public string ToyLink { get; set; }
        public override string ToString()
        {
            return new StringBuilder()
            .Append(_baseUrl)
            .Append(NumberPageLink)
            .Append(ToyLink)
            .ToString();
        }
    }
}
