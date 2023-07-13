using HistoricTracer.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HistoricTracer.webApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistorizationController : ControllerBase
    {

        private readonly IHistoricService _historic;
        public HistorizationController(IHistoricService historicService)
        {
            _historic = historicService;
        }
        // GET: api/<HistorizationController>
        [HttpGet]
        public async Task<IActionResult> Get(string filter, CancellationToken cancellationToken)
        {
            var historic = await _historic.GetAllHistoric(cancellationToken);

            if (!string.IsNullOrEmpty(filter))
            {
                historic = historic.Where(item => item.CollaboratorName == filter).ToList();
            }

            return Ok(historic);
        }

        [HttpGet("id")]
        public async Task<IActionResult>GetOne(string id, CancellationToken cancellationToken)
        {
            var historic = await _historic.GetOneHistoric(id, cancellationToken);
            if(historic == null)
            {
                return NotFound();
            }
            return Ok(historic);
        }

        // GET api/<HistorizationController>/5
        [HttpPost]
        public async Task<IActionResult> Post(CancellationToken cancellation)
        {
            var hist = await _historic.SaveHistoric(cancellation);
            return Ok(hist);
        }


    }
}
