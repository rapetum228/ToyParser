using ToyParser.Core.Csv;
using ToyParser.Core.Documents;
using ToyParser.Core.Parsing;
using ToyParser.Core.Parsing.ToyProperties;
using ToyParser.Core.Url;

namespace ToyParser.Core
{
    internal class ToyParserWorker
    {
        private readonly IUrlBuilder _urlBuilder;
        private readonly IUrlDirector<int> _urlPageDirector;
        private readonly DocumentCreator<int> _documentCreator;
        private readonly CustomCsvWriter _csvWriter;
        private readonly HttpClient _httpClient;
        public ToyParserWorker()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
            _urlBuilder = new UrlBuilder();
            _urlPageDirector = new UrlPageDirector(_urlBuilder);
            _documentCreator = new DocumentCreator<int>(_urlPageDirector, _httpClient);
            _csvWriter = new CustomCsvWriter();
        }

        private async void WorkerAsync(int numberPage)
        {
            var document = await _documentCreator.GetDocumentForParseAsync(numberPage);

            if (document is null)
            {
                throw new Exception("Страница не загружена");
            }

            ParserHelper parser = new ParserHelper(_httpClient);
            var list = await parser.ParsePageAsync(document, numberPage);
            _csvWriter.WriteList(list);

        }

        public async Task Start()
        {
            var document = await _documentCreator.GetDocumentForParseAsync(1);

            NumberPagesParser parser = new NumberPagesParser();
            var countPages = parser.Parse.Invoke(document);

            Parallel.For(1, countPages + 1, WorkerAsync);
        }


    }
}
