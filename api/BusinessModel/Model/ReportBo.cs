using API.Interfaces.Model;

namespace API.BusinessModel.Model
{
    public class ReportBo : IReportBo
    {
        public int TweetsPerMinutes { get; set; }
        public int TweetsPerSecond { get; set; }
        public int TweetsAmount { get; set; }
    }
}
