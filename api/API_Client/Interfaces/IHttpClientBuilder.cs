namespace Console_API_Client.Interfaces
{
    public interface IReportBuilder
    {
        IReportBuilder SetTweetsPerMinutesReport(int value);
        IReportBuilder SetTweetsPerSecondReport(int value);
        IReportBuilder SetTweetsAmount(int value);
        IReportBo MakeReport();
    }
}
