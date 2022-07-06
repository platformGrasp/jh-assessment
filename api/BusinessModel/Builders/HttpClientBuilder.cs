using System.Net;
using API.Interfaces.Builders;

namespace API.BusinessModel.Builders
{
    public class HttpClientBuilder: IHttpClientApiBuilder
    {
        private HttpWebRequest _webRequest;

        public IHttpClientApiBuilder SetWebRequest(string url)
        {
            _webRequest = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public IHttpClientApiBuilder SetTimeout(int timeout)
        {
            _webRequest.Timeout = timeout;
            return this;
        }

        public IHttpClientApiBuilder AddHeader(string name, string value)
        {
            _webRequest.Headers.Add(name, value);
            return this;
        }

        public IHttpClientApiBuilder SetMethod(string method)
        {
            _webRequest.Method = method;
            return this;
        }

        public HttpWebRequest MakeWebRequest()
        {
            return _webRequest;
        }
    }
}
