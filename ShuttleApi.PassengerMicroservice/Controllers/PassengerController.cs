using Microsoft.AspNetCore.Mvc;
using ShuttleApi.PassengerMicroservice.Services.Contracts;

namespace ShuttleApi.UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class PassengerController : Controller
    {
        private readonly IPassengerService _passengerService;
        //логиирование добавить
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
            //здесь будет логи
        }
        //дальше методы
    }
}
