using System;
using API.Interfaces;
using API.Interfaces.Services;

namespace API.BusinessModel.Services
{
    public class ReportWorker : IReportWorker
    {
        private readonly ICache _cache;
        private readonly DateTime _initTime;
        public ReportWorker(ICache cache)
        {
            _initTime = DateTime.Now;
            _cache = cache;
        }

        public int TweetsPerMinutesReport()
        {
            int tweetCount = _cache.Count();
            DateTime startTime = _initTime;
            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);
            double minutes = span.TotalMinutes < 1 ? 1 :  span.TotalMinutes;
            return minutes == 0 ? tweetCount : (int)(tweetCount / minutes);
        }

        public int TweetsPerSecondsReport()
        {
            int tweetCount = _cache.Count();
            DateTime startTime = _initTime;
            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(startTime);
            double seconds = (int)span.TotalSeconds;
            return seconds == 0 ? tweetCount : (int)(tweetCount / seconds);
        }

        public int TotalTweets()
        {
            return _cache.Count();
        }
    }
}
