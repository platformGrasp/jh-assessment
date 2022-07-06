namespace Console_API_Client.Interfaces
{
    public interface IReportBo
    {
        int tweetsPerMinutes { get; set; }
        int tweetsPerSecond { get; set; }
        int tweetsAmount { get; set; }
    }
}