using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentRequestDto request)
        {
            int id = await _service.CreatePaymentAsync(
                request.SupplierId,
                request.Amount,
                request.Remarks
            );

            return Ok(new { PaymentId = id });
        }
    }

}
