using System.Threading.Tasks;
using API.Interfaces.Model;

namespace API.Interfaces.Services
{
    public interface IApiFacade: IEventHandler
    {
        Task GetSearchStreamAsync();
        IDataResponseBo GetTwitterDetail(string id);
    }
}
