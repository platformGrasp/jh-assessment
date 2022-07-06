using System.Net;
using Console_API_Client.Interfaces;

namespace Console_API_Client.Infrastructure
{
    public class HttpFactory: IHttpFactory
    {
        private readonly IHttpClientApiBuilder _httpClientApiBuilder;

        public HttpFactory()
        {
            _httpClientApiBuilder = new HttpClientBuilder();
        }

        public HttpWebRequest MakeGetWebRequest(string url)
        {
            HttpWebRequest webRequest = _httpClientApiBuilder
                .SetWebRequest(url)
                .SetTimeout(60000)
                .SetMethod("GET")
                .MakeWebRequest();
            return webRequest;
        }
    }
}
