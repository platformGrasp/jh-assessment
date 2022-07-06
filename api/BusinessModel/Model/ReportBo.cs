using API.Interfaces.Model;

namespace API.BusinessModel.Model
{
    public class ReportBo : IReportBo
    {
        public int TweetsPerMinutes { get; set; }
        public int TweetsPerSecondReport { get; set; }
        public int TweetsAmount { get; set; }
    }
}
