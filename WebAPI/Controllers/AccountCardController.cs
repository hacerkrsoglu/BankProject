using Business.Abstract;
using Entities.DTOs.AccountCard;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCardController : ControllerBase
    {
        IAccountCardService _accountCardService;

        public AccountCardController(IAccountCardService accountCardService)
        {
            _accountCardService = accountCardService;
        }

        [HttpPost("update")]

        public IActionResult UpdateAccountCard([FromBody] AccountCardDto accountCardDto)
        {
            var result = _accountCardService.UpdateAccountCard(accountCardDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]

        public IActionResult DeleteAccountCard([FromQuery] int accountId, int creditCardId)
        {
            var result = _accountCardService.DeleteAccountCard(accountId, creditCardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
