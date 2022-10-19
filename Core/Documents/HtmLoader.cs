using System.Net;

namespace ToyParser.Core.Documents
{
    internal class HtmLoader
    {
        private readonly HttpClient _httpClient;
        //private readonly string _url;

        public HtmLoader(HttpClient httpClient)
        {
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = httpClient;
            //_url = url;
        }

        public async Task<string> GetSource(string url)
        {
            string source = String.Empty;
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        source = await response.Content.ReadAsStringAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return source;
        }
    }
}