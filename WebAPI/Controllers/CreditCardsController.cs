using Business.Abstract;
using Entities.DTOs.Account;
using Entities.DTOs.CreditCard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {

        ICreditCardService _creditCardService;//field oluşturduk

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("add")]//data ekleme
        public IActionResult Add([FromBody] CreditCardToAddDto creditCardToAdd)
        {

            var result = _creditCardService.Add(creditCardToAdd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetByUserId([FromQuery] int userId)
        {
            var result = _creditCardService.GetByUserId(userId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
    }
}
