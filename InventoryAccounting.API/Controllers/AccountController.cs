using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAccounting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService service)
        {
            _accountService = service;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetLedger(int accountId)
        {
            var data = await _accountService.GetLedgerAsync(accountId);
            return Ok(data);
        }

    }
}
