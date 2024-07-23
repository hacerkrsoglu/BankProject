using Business.Abstract;
using Entities.DTOs.Account;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountService _accountService;//field oluşturduk

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("add")]//data ekleme
        public IActionResult Add([FromBody] AccountToAdd accountToAdd)
        {

            var result = _accountService.Add(accountToAdd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetByUserId([FromQuery] int userId)
        {
            var result = _accountService.GetByUserId(userId);

            if (result.Success)
            {
                return Ok(result);
            }
           
            return BadRequest(result.Message);
            
        }
        [HttpPut("update-balance")]
        public IActionResult BalanceDepositOrWithdraw([FromBody] BalanceDepositOrWithDrawDto balanceDepositOrWithDrawDto)
        {
            var result = _accountService.BalanceDepositOrWithdraw(balanceDepositOrWithDrawDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("account-summaries")]
        public IActionResult GetAccountSummarriesByUserId([FromQuery] int userId)
        {
            var result = _accountService.GetAccountSummariesByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("accounts-for-seleciton")]
        public IActionResult GetAccountsForSelectionByUserId([FromQuery] int userId)
        {
            var result = _accountService.GetAccountsForSelectionByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
