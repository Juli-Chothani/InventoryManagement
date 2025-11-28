using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _service;

        public ReceiptController(IReceiptService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceipt(ReceiptRequestDto model)
        {
            var id = await _service.CreateReceiptAsync(model.CustomerId, model.Amount, model.Remarks);
            return Ok(new { ReceiptId = id, Message = "Receipt created successfully" });
        }
    }

}
