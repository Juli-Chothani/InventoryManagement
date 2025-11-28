using Microsoft.AspNetCore.Mvc;
using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Service.Services;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly PurchaseService _service;

        public PurchasesController(PurchaseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase([FromBody] PurchaseDto dto)
        {
            var id = await _service.CreatePurchaseAsync(dto);
            return Ok(new { PurchaseId = id });
        }
    }
}
