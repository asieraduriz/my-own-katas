using Courier.Handlers;
using Courier.Models;
using Microsoft.AspNetCore.Mvc;

namespace Courier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly ICourierHandler courierHandler;

        public CourierController(ICourierHandler courierHandler)
        {
            this.courierHandler = courierHandler;
        }

        // POST: api/Courier
        [HttpPost]
        public CourierResponse Post([FromBody] CourierQuery query)
        {
            return courierHandler.Handle(query);
        }
    }
}
