using Microsoft.AspNetCore.Mvc;
using ShuttleApi.ShuttleMicroservice.Services.Contracts;
using NLog;
using ShuttleApi.ShuttleMicroservice.Data.DTOs;

namespace ShuttleApi.ShuttleMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ShuttleController : Controller
    {
        private readonly IShuttleService _shuttleService;
        //логгирование будет использоваться для ошибок, так как логи о создании, удалении объекта и тд вшиты в сервис
        private readonly Logger _logger;
        public ShuttleController(IShuttleService shuttleService)
        {
            _shuttleService = shuttleService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpPost("CreateShuttle")]
        public async Task<ActionResult> CreateShuttle([FromBody] ShuttleDTO shuttleDTO, [FromQuery] CancellationToken cancellationToken)
        {
            await _shuttleService.CreateShuttle(shuttleDTO, cancellationToken);
            return Ok();
        }

        [HttpGet("GetShuttleById")]
        public async Task<ActionResult<ShuttleDTO>> GetShuttleById([FromBody] Guid shuttleId, [FromQuery] CancellationToken cancellationToken)
        {
            var shuttle =  await _shuttleService.GetShuttleById(shuttleId, cancellationToken);
            return Ok(shuttle);
        }

        [HttpGet("GetShuttleByTitle")]
        public async Task<ActionResult<ShuttleDTO>> GetShuttleByTitle([FromBody] string shuttleTitle, [FromQuery] CancellationToken cancellationToken)
        {
            var shuttle =  await _shuttleService.GetShuttleByTitle(shuttleTitle, cancellationToken);
            return Ok(shuttle);
        }

        [HttpGet("GetAllShuttles")]
        public async Task<ActionResult<IEnumerable<ShuttleDTO>>> GetAllShuttles([FromQuery] CancellationToken cancellationToken)
        {
            var listOfShuttles = await _shuttleService.GetAllShuttles(cancellationToken);
            return Ok(listOfShuttles);
        }
    }
}
