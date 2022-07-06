using API.Interfaces.Model;

namespace API.Interfaces.Builders
{
    public interface IReportBuilder
    {
        IReportBuilder SetTweetsPerMinutesReport(int value);
        IReportBuilder SetTweetsPerSecondReport(int value);
        IReportBuilder SetTweetsAmount(int value);
        IReportBo MakeReport();
    }
}
