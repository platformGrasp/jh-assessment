using System;
using API.Business.Constants;
using API.Interfaces.Model;
using API.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using TwitterAPI_Assessment.HubConfig;

namespace TwitterAPI_Assessment.Infrastructure
{
    public class ThreadWork
    {
        private static IHubContext<ChartHub> _hub;
        private static IWorker _twitterUnitOfWork;

        public static void Init(IHubContext<ChartHub> hub, IWorker twitterUnitOfWork)
        {
            _hub = hub;
            _twitterUnitOfWork = twitterUnitOfWork;
        }

        public static void DoWork( )
        {
            _twitterUnitOfWork.StreamTweetProcessed += HandleCustomEvent;
            _twitterUnitOfWork.StreamError += HandleCustomEventError;
            _twitterUnitOfWork.ProcessStreamAsync();
        }

        static void HandleCustomEvent(object sender, IStreamDataResponseBo data)
        {
            _hub?.Clients.All.SendAsync(HubConstants.TRANSFERCHARTDATA, data);
            Console.WriteLine(data);
        }

        static void HandleCustomEventError(object sender, Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}