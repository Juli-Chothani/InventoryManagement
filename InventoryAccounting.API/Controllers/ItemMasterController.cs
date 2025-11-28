using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemMasterController : Controller
    {
        private readonly IItemMasterService _service;

        public ItemMasterController(IItemMasterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemMasterDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(new { ItemId = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
