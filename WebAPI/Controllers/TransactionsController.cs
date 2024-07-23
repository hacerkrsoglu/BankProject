using Business.Abstract;
using Entities.DTOs.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult Insert([FromBody]TransactionToAdd transactionToAdd)
        {
            var result = _transactionService.Insert(transactionToAdd);
            return Ok(result);
        }
    }
}
