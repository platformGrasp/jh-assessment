using System.Net;

namespace API.Interfaces.Factory
{
    public interface IHttpFactory
    {
        HttpWebRequest MakeGetWebRequest(string url);
    }
}