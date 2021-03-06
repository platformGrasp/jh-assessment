using API.Business.Model;
using API.Interfaces.Builders;
using API.Interfaces.Model;

namespace API.Business.Builders
{
    public class ReportBuilder : IReportBuilder
    {
        private int _tweetsPerSecondReport;
        private int _tweetsPerMinutesReport;
        private int _tweetsAmount;

        public IReportBuilder SetTweetsPerMinutesReport(int value)
        {
            _tweetsPerMinutesReport = value;
            return this;
        }

        public IReportBuilder SetTweetsPerSecondReport(int value)
        {
            _tweetsPerSecondReport = value;
            return this;
        }

        public IReportBuilder SetTweetsAmount(int value)
        {
            _tweetsAmount = value;
            return this;
        }

        public IReportBo MakeReport()
        {
            return new ReportBo
            {
                TweetsPerMinutes = _tweetsPerMinutesReport,
                TweetsPerSecond = _tweetsPerSecondReport,
                TweetsAmount = _tweetsAmount
            };
        }
    }
}
