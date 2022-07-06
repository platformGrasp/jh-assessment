using API.Interfaces.Builders;
using API.Interfaces.Factory;
using API.Interfaces.Model;
using API.Interfaces.Services;

namespace API.BusinessModel.Factory
{
    public class ReportFactory : IReportFactory
    {
        private readonly IReportWorker _reportWorker;
        private readonly IReportBuilder _reportBuilder;

        public ReportFactory(IReportWorker reportWorker, IReportBuilder reportBuilder)
        {
            _reportWorker = reportWorker;
            _reportBuilder = reportBuilder;
        }

        public IReportBo MakeReport()
        {
            IReportBo report = _reportBuilder.SetTweetsPerMinutesReport(_reportWorker.TweetsPerMinutesReport())
                .SetTweetsPerSecondReport(_reportWorker.TweetsPerSecondsReport())
                .SetTweetsAmount(_reportWorker.TotalTweets())
                .MakeReport();
            return report;
        }
    }
}
