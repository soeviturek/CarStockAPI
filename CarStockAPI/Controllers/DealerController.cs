using CarStockAPI.Data;
using CarStockAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IDealers _dealersService;


        public DealerController(IDealers dealerService) {

            _dealersService = dealerService;
        }

        [HttpGet("getAllApiKeys")]
        public IEnumerable<KeyValuePair<string,string>> Get()
        {
            return _dealersService.GetAllAPIKeys();
        }
        // POST api/<DealerController>
        [HttpPost("register")]
        public string Post(string Id)
        {
            Dealer dealer = _dealersService.RegisterDealer(Id);
            if(dealer == null)
            {
                Response.StatusCode = 409;
                return "Failed to register, try a different id.";
            }
            return dealer.ToString();
        }
    }
}
