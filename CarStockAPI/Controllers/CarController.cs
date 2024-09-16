using CarStockAPI.Data;
using CarStockAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICar _carService;
        private readonly IDealers _dealerService;

        public CarController(ICar carService, IDealers dealerService)
        {
            _carService = carService;
            _dealerService = dealerService;
        }

        [Authorize]
        [HttpGet("getAllCars")]
        public List<Car> Get()
        {
            string dealerId = GetDealerId();
            if (string.IsNullOrEmpty(dealerId))
            {
                return new List<Car>();
            }
            return _carService.GetAllCar(GetDealerId());
        }

        [Authorize]
        [HttpGet("{id}")]
        public string Get(string id)
        {
            Car car = _carService.GetCar(id, GetDealerId());
            if(car == null)
            {
                Response.StatusCode = 404;
                return "Car not found!";
            }
            return car.ToString();
        }

        [Authorize]
        [HttpPost]
        public string Post(string Make, string Model, int Year)
        {
            Car car = new Car(Make, Model, Year, GetDealerId());
            if (_carService.AddCar(car))
            {
                return String.Format("Car added!\n{0}",car.ToString());
            }
            Response.StatusCode = 500;
            return "Unkown Error!";
        }

        [HttpPut("{id}")]
        public string Put(string id, string Make, string Model, int Year)
        {
            Car car = new Car(id,Make, Model, Year, GetDealerId());
            if (_carService.EditCar(car))
            {
                return "Car updated!";
            }
            Response.StatusCode = 500;
            return "Unkown Error!";
        }

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            if(_carService.RemoveCar(id, GetDealerId()))
            {
                return "Car deleted!";
            }
            Response.StatusCode = 500;
            return "Unkown Error!";
        }
        private string GetDealerId()
        {
            //Request.Headers.TryGetValue("x-api-key", out var apiKey);
            string apiKey = Request.Headers["x-api-key"];
            if (String.IsNullOrEmpty(apiKey))
            {
                return "";
            }
            return _dealerService.GetDealerId(apiKey);
        }
    }
}
