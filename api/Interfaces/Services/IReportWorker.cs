namespace API.Interfaces.Services
{
    public interface IReportWorker
    {
        int TweetsPerMinutesReport();
        int TweetsPerSecondsReport();
        int TotalTweets();
    }
}
