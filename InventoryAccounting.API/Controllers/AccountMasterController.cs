using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountMasterController : ControllerBase
    {
        private readonly IAccountMasterService _service;

        public AccountMasterController(IAccountMasterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountDto dto)
        {
            var id = await _service.CreateAccountAsync(dto);
            return Ok(new { AccountId = id });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("ledger/{accountId}")]
        public async Task<IActionResult> GetLedger(int accountId)
        {
            var result = await _service.GetAccountLedgerAsync(accountId);
            return Ok(result);
        }
    }
}

