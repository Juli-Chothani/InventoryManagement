using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _service;

        public SalesController(SaleService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(CreateSaleDto dto)
        {
            var id = await _service.CreateSaleAsync(dto);

            return Ok(new { SaleId = id });
        }
    }

}
