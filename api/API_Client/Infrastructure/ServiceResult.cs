using System.Net;

namespace Console_API_Client.Infrastructure
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Message = new Message();
        }
        public bool HasError { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public Message Message { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public virtual T result { get; set; }
    }

    public class Message
    {
        public Message()
        {
            Description = "";
            Code = "200";
        }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
