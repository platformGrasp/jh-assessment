using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Business.Extensions;
using API.Domain.Model.ApiModel;
using API.Interfaces;
using API.Interfaces.Factory;
using API.Interfaces.Model;
using API.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace API.Business.Services
{
    public class ApiFacade: IApiFacade
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IHttpFactory _httpFactory;
        private event EventHandler<string> StreamRead;
        private event EventHandler<Exception> StreamError;
        private readonly ILogger _logger;

        public event EventHandler<string> StreamReadEvent
        {
            add => StreamRead += value;
            remove => StreamRead -= value;
        }

        public event EventHandler<Exception> StreamErrorEvent
        {
            add => StreamError += value;
            remove => StreamError -= value;
        }

        public ApiFacade(IAppConfiguration appConfiguration, IHttpFactory httpFactory, ILogger<ApiFacade> logger)
        {
            _appConfiguration = appConfiguration;
            _httpFactory = httpFactory;
            _logger = logger;
        }

        IDataResponseBo IApiFacade.GetTwitterDetail(string id)
        {
            HttpWebRequest webRequest =
                _httpFactory.MakeGetWebRequest(
                    $"{_appConfiguration.ApiUrl}/2/tweets/{id}?tweet.fields=&expansions=&media.fields=&place.fields=&poll.fields=&user.fields=");
            string jsonText ="";
            try
            {
                var encode = Encoding.GetEncoding("utf-8");
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var responseStream = new StreamReader(webResponse.GetResponseStream(), encode);
                jsonText = responseStream.ReadToEnd(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                OnStreamError(ex);
            }
            finally
            {
                webRequest.Abort();
            }
            var outputResponse = JsonSerializer.Deserialize<Response>(jsonText);
            IDataResponseBo output = outputResponse.AsDataResponse();
            return output;
        }

        public Task GetSearchStreamAsync()
        {
            HttpWebRequest webRequest =
                _httpFactory.MakeGetWebRequest(
                    $"{_appConfiguration.ApiUrl}/2/tweets/sample/stream?tweet.fields=public_metrics");
            try
            {
                var encode = Encoding.GetEncoding("utf-8");
                var webResponse = (HttpWebResponse) webRequest.GetResponse();
                var responseStream = new StreamReader(webResponse.GetResponseStream(), encode);
                while (!responseStream.EndOfStream)
                {
                    var jsonText = responseStream.ReadLine();
                    if (!string.IsNullOrEmpty(jsonText))
                        OnStreamRead(jsonText);
                }
                responseStream.Close();
                webResponse.Close();
            }
            catch (WebException ex)
            {
                _logger.LogError(ex, ex.Message);
                OnStreamError(ex);
            }
            finally
            {
                webRequest.Abort();
            }

            return Task.CompletedTask;
        }

        protected virtual void OnStreamRead(string e)
        {
            StreamRead?.Invoke(this, e);
        }

        protected virtual void OnStreamError(Exception e)
        {
            StreamError?.Invoke(this, e);
        }
    }
}
