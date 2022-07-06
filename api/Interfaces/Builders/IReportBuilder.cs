using System.Net;

namespace API.Interfaces.Builders
{
    public interface IHttpClientApiBuilder
    {
        IHttpClientApiBuilder SetWebRequest(string url);
        IHttpClientApiBuilder SetTimeout(int timeout);
        IHttpClientApiBuilder AddHeader(string authorization, string s);
        IHttpClientApiBuilder SetMethod(string method);
        HttpWebRequest MakeWebRequest();
    }
}
