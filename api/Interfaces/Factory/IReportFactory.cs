using API.Interfaces.Model;

namespace API.Interfaces.Factory
{
    public interface IReportFactory
    {
        IReportBo MakeReport();
    }
}
