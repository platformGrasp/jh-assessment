using System.Net;
using System.Threading.Tasks;
using API.Business.Model;
using API.Interfaces.Factory;
using API.Interfaces.Model;
using Microsoft.AspNetCore.Mvc;
using TwitterAPI_Assessment.Service;

namespace TwitterAPI_Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportFactory _reportFactory;
        public ReportController(IReportFactory reportFactory)
        {
            _reportFactory = reportFactory;
        }

        [HttpGet()]
        public async Task<ServiceResult<ReportBo>> Get()
        {
            IReportBo report = _reportFactory.MakeReport();
            var resultOk = new ServiceResult<ReportBo>
            {
                Result = (ReportBo)report
            };
            resultOk.HttpStatusCode =
                resultOk.Result != null ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return await Task.FromResult(resultOk);
        }
    }
}
