using Microsoft.AspNetCore.Mvc;
using ShuttleApi.PilotMicroservice.Services.Contracts;
using ShuttleApi.PilotMicroservice.Models;
using NLog;
using ShuttleApi.PilotMicroservice.Data.DTOs;

namespace ShuttleApi.PilotMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class PilotController : Controller
    {
        private readonly IPilotService _pilotService;
        //логгирование будет использоваться для ошибок, так как логи о создании, удалении объекта и тд вшиты в сервис
        private readonly Logger _logger;
        public PilotController(IPilotService pilotService)
        {
            _pilotService = pilotService;
            _logger = LogManager.GetCurrentClassLogger();
            //здесь будет логи
        }
        [HttpPost("CreatePilot")]
        public async Task<ActionResult> CreatePassenger([FromBody] PilotDTO pilotDto, [FromBody] string password)
        {
            await _pilotService.CreatePilot(pilotDto, password);
            return Ok();
        }

        [HttpGet("GetPilotById")]
        public async Task<ActionResult<PilotDTO>> GetShuttleById([FromBody] string pilotId)
        {
            var passenger = await _pilotService.GetPilotById(pilotId);
            return Ok(passenger);
        }

        [HttpPost("DeletePilot")]
        public async Task<ActionResult> DeletePilot([FromBody] string pilotId)
        {
            await _pilotService.DeletePilot(pilotId);
            return Ok();
        }

        [HttpGet("GetAllPilots")]
        public async Task<ActionResult<IEnumerable<PilotDTO>>> GetAllPassengers()
        {
            var listOfPassengers = await _pilotService.GetAllPilots();
            return Ok(listOfPassengers);
        }
    }
}
