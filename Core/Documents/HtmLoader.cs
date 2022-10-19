using System.Net;
using System.Net.Sockets;

namespace ToyParser.Core.Documents
{
    internal class HtmLoader
    {
        private readonly HttpClient _httpClient;
        private readonly string _exceptionMessage = "Проблемы с соединением, попробуйте позже: ";

        public HtmLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            catch (HttpRequestException ex)
            {
                Console.WriteLine(_exceptionMessage + ex.Message);
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(_exceptionMessage + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(_exceptionMessage + ex.Message);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(_exceptionMessage + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return source;
        }
    }
}