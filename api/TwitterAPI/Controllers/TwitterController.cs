using API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TwitterAPI_Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitterController : Controller
    {
        private readonly IApiFacade _twitterApiFacade;
        public TwitterController(IApiFacade twitterApiFacade)
        {
            _twitterApiFacade = twitterApiFacade;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var response = _twitterApiFacade.GetTwitterDetail(id);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
