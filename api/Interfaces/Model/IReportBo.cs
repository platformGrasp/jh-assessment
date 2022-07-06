namespace API.Interfaces.Model
{
    public interface IReportBo
    {
        int TweetsPerMinutes { get; set; }
        int TweetsPerSecondReport { get; set; }
        int TweetsAmount { get; set; }
    }
}