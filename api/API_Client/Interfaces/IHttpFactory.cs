using System.Net;

namespace Console_API_Client.Interfaces
{
    public interface IHttpFactory
    {
        HttpWebRequest MakeGetWebRequest(string url);
    }
}