using System;
using System.Threading.Tasks;
using API.Interfaces.Model;

namespace API.Interfaces.Services
{
    public interface IWorker
    {
        event EventHandler<IStreamDataResponseBo> StreamTweetProcessed;
        event EventHandler<Exception> StreamError;
        Task ProcessStreamAsync();
    }
}
