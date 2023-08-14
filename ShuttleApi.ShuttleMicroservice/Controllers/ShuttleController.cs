using Microsoft.AspNetCore.Mvc;
using ShuttleApi.ShuttleMicroservice.Services.Contracts;
using ShuttleApi.ShuttleMicroservice.Models;

namespace ShuttleApi.ShuttleMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ShuttleController : Controller
    {
        private readonly IShuttleService _shuttleService;
        //логиирование добавить
        public ShuttleController(IShuttleService shuttleService)
        {
            _shuttleService = shuttleService;
            //здесь будет логи
        }
        //дальше методы
    }
}
