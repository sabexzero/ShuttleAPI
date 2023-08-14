using Microsoft.AspNetCore.Mvc;
using ShuttleApi.FlightsMicroservice.Services.Contracts;

namespace ShuttleApi.FlightsMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : Controller
    {
        private readonly IFlightsService _flightsService;
        //логиирование добавить
        public FlightController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
            //здесь будет логи
        }
        //дальше методы
    }
}
