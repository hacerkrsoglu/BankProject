using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private readonly ITransaction _transaciton;
        private readonly IAccountDal _accountDal;

        public TransactionManager(ITransaction transaciton, IAccountDal accountDal)
        {
            _transaciton = transaciton;
            _accountDal = accountDal;
        }

        public IResult Insert(TransactionToAdd transactionToAdd)
        {
            var senderAccount = _accountDal.GetAccountById(transactionToAdd.SenderAccountId);

            if (senderAccount.Balance < transactionToAdd.Amount)
            {
                return new ErrorResult("Fakirsiniz..");
            }

            Entities.Concrete.Transaction transaciton = new();
            transaciton.Amount = transactionToAdd.Amount;
            transaciton.SenderAccountId = transactionToAdd.SenderAccountId;
            transaciton.Description = "Para transferi";
            transaciton.TransactionDate = DateTime.Now;

            if (transactionToAdd.RecieverAccountId > 0 && string.IsNullOrEmpty(transactionToAdd.IBAN))
            {
                transaciton.ReceiverAccountId = transactionToAdd.RecieverAccountId;
                var recieverAccount = _accountDal.GetAccountById(transactionToAdd.RecieverAccountId);

                recieverAccount.Balance += transactionToAdd.Amount;

                _accountDal.Update(recieverAccount);
            }

            if (!string.IsNullOrEmpty(transactionToAdd.IBAN) && transactionToAdd.RecieverAccountId == 0)
            {
                var recieverAccount = _accountDal.Get(x => x.IBAN == transactionToAdd.IBAN);
                recieverAccount.Balance += transactionToAdd.Amount;

                _accountDal.Update(recieverAccount);

                transaciton.ReceiverAccountId = recieverAccount.Id;
            }

            senderAccount.Balance -= transactionToAdd.Amount;

            _accountDal.Update(senderAccount);
            _transaciton.Add(transaciton);

            return new SuccessResult("Transfer başarılı");
        }
    }
}
