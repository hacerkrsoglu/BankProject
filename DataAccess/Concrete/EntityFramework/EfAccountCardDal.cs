using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAccountCardDal : EfEntityRepositoryBase<AccountCard, PostgreSqlContext>, IAccountCardDal
    {
      

        public AccountCard GetByAccountIdOrCreditCardId(int accountId, int creditCardId)
        {
            using (PostgreSqlContext context = new PostgreSqlContext())
            {
                return context.AccountCard.FirstOrDefault(x => x.AccountId == accountId || x.CreditCardId == creditCardId);

            }
        }
    }
}
