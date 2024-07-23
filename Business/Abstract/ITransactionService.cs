using Core.Utilities.Results;
using Entities.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        IResult Insert(TransactionToAdd transactionToAdd);
    }
}
