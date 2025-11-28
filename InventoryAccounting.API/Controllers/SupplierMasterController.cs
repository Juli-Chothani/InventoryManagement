using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierMasterController : ControllerBase
    {
        private readonly ISupplierMasterServices _service;

        public SupplierMasterController(ISupplierMasterServices service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierDto dto)
        {
            var id = await _service.CreateSupplierAsync(dto);
            return Ok(new { SupplierId = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _service.GetAllAsync();
            return Ok(suppliers);
        }
    }

}
