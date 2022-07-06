using System.Net;
using API.Interfaces;
using API.Interfaces.Builders;
using API.Interfaces.Factory;

namespace API.BusinessModel.Factory
{
    public class HttpFactory: IHttpFactory
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IHttpClientApiBuilder _httpClientApiBuilder;

        public HttpFactory(IAppConfiguration appConfiguration, IHttpClientApiBuilder httpClientApiBuilder)
        {
            _appConfiguration = appConfiguration;
            _httpClientApiBuilder = httpClientApiBuilder;
        }

        public HttpWebRequest MakeGetWebRequest(string url)
        {
            HttpWebRequest webRequest = _httpClientApiBuilder
                .SetWebRequest(url)
                .SetTimeout(60000)
                .AddHeader("Authorization", $"Bearer {_appConfiguration.BearerToken}")
                .SetMethod("GET")
                .MakeWebRequest();
            return webRequest;
        }
    }
}
