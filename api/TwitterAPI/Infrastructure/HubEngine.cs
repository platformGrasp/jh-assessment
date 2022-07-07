using System;
using API.Business.Constants;
using API.Interfaces.Model;
using API.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using TwitterAPI_Assessment.HubConfig;

namespace TwitterAPI_Assessment.Infrastructure
{
    public class HubEngine
    {
        private static IHubContext<ChartHub> _hub;
        private static IWorker _twitterUnitOfWork;
        private static ILogger _logger;

        public static void Init(IHubContext<ChartHub> hub, IWorker twitterUnitOfWork, ILogger logger)
        {
            _hub = hub;
            _twitterUnitOfWork = twitterUnitOfWork;
            _logger = logger;
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
            
        }

        static void HandleCustomEventError(object sender, Exception exception)
        {
            _logger.LogError(exception, exception.Message);
        }
    }
}