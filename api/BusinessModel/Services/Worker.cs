using System;
using System.Text.Json;
using System.Threading.Tasks;
using API.BusinessModel.Constants;
using API.BusinessModel.Extensions;
using API.Domain.Model.ApiModel;
using API.Interfaces;
using API.Interfaces.Model;
using API.Interfaces.Services;

namespace API.BusinessModel.Services
{
    public class Worker : IWorker
    {
        private readonly ICache _cache;
        private readonly IApiFacade _twitterApiFacade;

        void HandleCustomEvent(object sender, string data)
        {
            StreamResponse response = JsonSerializer.Deserialize<StreamResponse>(data);
            var tweetBo = response.AsStreamDataResponse();
            if (tweetBo != null)
            {
                var cacheKey = $"{CacheConstants.TWEET}{tweetBo.Id}";
                _cache.Set(cacheKey, tweetBo);
                OnStreamTweetProcessed(tweetBo);
                Console.WriteLine(data);
            }
        }

        void HandleError(object sender, Exception e)
        {
            OnStreamError(e);
        }

        public Worker(ICache cache, IApiFacade twitterApiFacade, IReportWorker streamResponseBuilder)
        {
            _cache = cache;
            _twitterApiFacade = twitterApiFacade;
            _twitterApiFacade.StreamReadEvent += HandleCustomEvent;
            _twitterApiFacade.StreamErrorEvent += HandleError;
        }

        public event EventHandler<IStreamDataResponseBo> StreamTweetProcessed;
        public event EventHandler<Exception> StreamError;

        public async Task ProcessStreamAsync() => await _twitterApiFacade.GetSearchStreamAsync();

        protected virtual void OnStreamTweetProcessed(IStreamDataResponseBo e) => StreamTweetProcessed?.Invoke(this, e);

        protected virtual void OnStreamError(Exception e) => StreamError?.Invoke(this, e);
    }
}
