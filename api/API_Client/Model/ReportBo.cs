using Console_API_Client.Interfaces;

namespace Console_API_Client.Model
{
    public class ReportBo : IReportBo
    {
        public int tweetsPerMinutes { get; set; }
        public int tweetsPerSecond { get; set; }
        public int tweetsAmount { get; set; }
    }
}
