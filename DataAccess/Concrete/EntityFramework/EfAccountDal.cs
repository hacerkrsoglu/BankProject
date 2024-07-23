using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAccountDal : EfEntityRepositoryBase<Account, PostgreSqlContext>, IAccountDal
    {
        public Account GetAccountById(int accountId)
        {
            using (PostgreSqlContext context = new PostgreSqlContext())
            {
                return context.Accounts.FirstOrDefault(a => a.Id == accountId);

            }
        }

        public List<AccountToSelect> GetAccountsForSelectByUserId(int userId)
        {
            using (PostgreSqlContext context = new())
            {
                var result = context.Accounts
                    .Where(x => x.UserId == userId)
                    .Select(x => new AccountToSelect
                    {
                        Id = x.Id,
                        AccountNo = x.AccountNo
                    }).ToList();

                return result;
            }
        }

        public List<AccountToGetDto> GetByUserId(int userId)
        {
            using (PostgreSqlContext context = new PostgreSqlContext())
            {
                var result =  context.Accounts
                    .Where(x => x.UserId == userId)
                    .Include(x => x.AccountPurpose)
                    .Include(x => x.AccountType)
                    .Include(x=> x.Currency)
                    .Include(x => x.Card)
                    .ThenInclude(x => x.CreditCard)
                    .Select(x => new AccountToGetDto
                    {
                        UserId = x.UserId,
                        AccountPurposeId = x.AccountPurposeId,
                        AccountTypeId = x.AccountTypeId,
                        CurrencyId = x.CurrencyId,
                        AccountPurposeName = x.AccountPurpose.Name,
                        AccountCurrencyName = x.Currency.CurrencyType,
                        AccountTypeName = x.AccountType.Name,
                        AccountId = x.Id,
                        AccountNo = x.AccountNo,
                        Balance = x.Balance,
                        IBAN = x.IBAN,
                        CreditCardId = x.Card.CreditCardId,
                        CreditCardName = x.Card.CreditCard.CardNumber
                    })
                    .ToList();
                return result;
            }
        }

        public List<AccountDetailsWithTransactions> GetSummaryByUserId(int userId)
        {
            using (PostgreSqlContext context = new())
            {
                var result = context.Accounts
                    .Where(x => x.UserId == userId)
                    .Include(x => x.Transactions)
                        .ThenInclude(x => x.SenderAccount)
                    .Include(x => x.Currency)
                    .Select(x => new AccountDetailsWithTransactions()
                    {
                        AccountNo = x.AccountNo,
                        Balance = x.Balance,
                        CreateDate = x.CreateDate,
                        Transactions = x.Transactions.ToArray(),
                        Currency = x.Currency.CurrencyType
                    }).ToList();

                return result;

            }
        }
    }
}
