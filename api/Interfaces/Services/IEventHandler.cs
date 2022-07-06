using System;

namespace API.Interfaces.Services
{
    public interface IEventHandler
    {
        event EventHandler<string> StreamReadEvent;
        event EventHandler<Exception> StreamErrorEvent;
    }
}
