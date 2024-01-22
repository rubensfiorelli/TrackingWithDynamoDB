using DynamoDB.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDB.Api.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ShippingServicesController : ControllerBase
    {

        private readonly IShippingServiceService _service;

        public ShippingServicesController(IShippingServiceService service) => _service = service;
       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var existing = await _service.GetAll();

            return Ok(existing);
        }
    }
}
