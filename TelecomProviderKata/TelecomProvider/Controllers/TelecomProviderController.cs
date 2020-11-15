using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TelecomProvider.Exceptions;
using TelecomProvider.Handlers;
using TelecomProvider.Model;
using ContractPhone = TelecomProvider.Controllers.TelecomProviderContract.DTO.Phone;

namespace TelecomProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelecomProviderController : ControllerBase
    {
        private readonly ITelecomProviderHandler telecomProviderHandler;

        public TelecomProviderController(ITelecomProviderHandler telecomProviderHandler)
        {
            this.telecomProviderHandler = telecomProviderHandler;
        }

        // GET: api/TelecomProvider
        [HttpGet]
        public List<Phone> Get()
        {
            return telecomProviderHandler.GetAllPhones();
        }

        // GET: api/TelecomProvider/5
        [HttpGet("{id}")]
        public List<Phone> Get(int id)
        {
            return telecomProviderHandler.GetCustomerPhones(id);
        }

        // POST: api/TelecomProvider
        [HttpPost]
        public IActionResult Post([FromBody] ContractPhone newPhone)
        {
            try
            {
                telecomProviderHandler.ActivatePhone(newPhone);
                return StatusCode(201);
            } catch(AlreadyRegisteredException)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/TelecomProvider/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
