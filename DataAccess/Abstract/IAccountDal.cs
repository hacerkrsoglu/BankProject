using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Account;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAccountDal: IEntityRepository<Account>
    {
        Account GetAccountById(int accountId);
        List<AccountToGetDto> GetByUserId(int userId);
        List<AccountDetailsWithTransactions> GetSummaryByUserId(int userId);
        List<AccountToSelect> GetAccountsForSelectByUserId(int userId);
    }
}
