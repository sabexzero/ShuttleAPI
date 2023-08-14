using Microsoft.AspNetCore.Mvc;
using ShuttleApi.PilotMicroservice.Services.Contracts;
using ShuttleApi.PilotMicroservice.Models;

namespace ShuttleApi.PilotMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class PilotController : Controller
    {
        private readonly IPilotService _pilotService;
        //логиирование добавить
        public PilotController(IPilotService pilotService)
        {
            _pilotService = pilotService;
            //здесь будет логи
        }
        //дальше методы
    }
}
