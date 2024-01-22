using DynamoDB.Application.InputModels;
using DynamoDB.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDB.Api.Controllers
{
    [Route("api/shipping-orders")]
    [ApiController]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly IShippingOrderService _service;

        public ShippingOrdersController(IShippingOrderService service) => _service = service;

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var existing = await _service.GetByCode(code);

            return Ok(existing);

        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderInputModel model)
        {
            var code = await _service.Add(model);

            return CreatedAtAction(nameof(GetByCode), new { code }, model);
        }
    }
}
