using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhonStore.Data;
using System.Diagnostics;

namespace PhonStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly PhoneStoreDB _phoneStoreDB;
        public StoreController(PhoneStoreDB phoneStoreDB) 
        {
            _phoneStoreDB = phoneStoreDB;
        }
        [HttpGet("priceAll")]
        public IActionResult GetPrice()
        {
            var prices = _phoneStoreDB.cosherPhones.Sum(p => p.price * p.Quantity);
            prices += _phoneStoreDB.unCosherPhones.Sum(p => p.price * p.Quantity);
            return Ok(new {message = "sucsses", price = prices});
        }
        [HttpGet("companies")]
        public IActionResult GetCompanies()
        {
            var companies = _phoneStoreDB.unCosherPhones.Select(p => p.Conpany).ToList();
            var coshercompanies = _phoneStoreDB.cosherPhones.Select(p => p.Conpany).ToList();
            return Ok(new { message = "sucsses", uncoshercompanies = companies, coshercompanies  = coshercompanies});

        }
    }
}
