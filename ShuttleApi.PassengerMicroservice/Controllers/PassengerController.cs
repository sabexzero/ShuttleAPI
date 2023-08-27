using Microsoft.AspNetCore.Mvc;
using NLog;
using ShuttleApi.PassengerMicroservice.Data.DTOs;
using ShuttleApi.PassengerMicroservice.Services;
using ShuttleApi.PassengerMicroservice.Services.Contracts;

namespace ShuttleApi.UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class PassengerController : Controller
    {
        private readonly IPassengerService _passengerService;
        //логгирование будет использоваться для ошибок, так как логи о создании, удалении объекта и тд вшиты в сервис
        private readonly Logger _logger;
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpPost("CreatePassenger")]
        public async Task<ActionResult> CreatePassenger([FromBody] PassengerDTO passengerDto, [FromBody] string password)
        {
            await _passengerService.CreatePassenger(passengerDto, password);
            return Ok();
        }

        [HttpGet("GetPassengerById")]
        public async Task<ActionResult<PassengerDTO>> GetShuttleById([FromBody] string shuttleId)
        {
            var passenger = await _passengerService.GetPassengerById(shuttleId);
            return Ok(passenger);
        }

        [HttpGet("GetAllPassengers")]
        public async Task<ActionResult<IEnumerable<PassengerDTO>>> GetAllPassengers()
        {
            var listOfPassengers = await _passengerService.GetAllPassengers();
            return Ok(listOfPassengers);
        }
    }
}
