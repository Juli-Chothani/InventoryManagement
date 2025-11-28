using InventoryAccounting.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _service;

        public ItemController(ItemService service)
        {
            _service = service;
        }

        [HttpPost("increase")]
        public async Task<IActionResult> IncreaseStock(int itemId, decimal qty)
        {
            await _service.IncreaseStock(itemId, qty);
            return Ok("Stock increased");
        }

        [HttpPost("decrease")]
        public async Task<IActionResult> DecreaseStock(int itemId, decimal qty)
        {
            await _service.DecreaseStock(itemId, qty);
            return Ok("Stock decreased");
        }
    }
}
