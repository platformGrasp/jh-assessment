namespace API.Interfaces.Model
{
    public interface IReportBo
    {
        int TweetsPerMinutes { get; set; }
        int TweetsPerSecond { get; set; }
        int TweetsAmount { get; set; }
    }
}