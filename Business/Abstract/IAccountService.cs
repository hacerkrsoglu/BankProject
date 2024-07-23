using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountService
    {
        IResult Add(AccountToAdd accountToAdd);
        IResult Delete(int accountId);

        IDataResult<Account> UpdateAccount(AccountToUpdate accountToUpdate );
        //Bu yapı, güncellenmiş Account nesnesi ile birlikte işlem sonucunu döndürecektir.
        //Bu sayede, hem güncellenmiş nesneye erişebilir hem de işlem sonucunu kontrol edebilirim.

        //silme , güncelleme işlemlerini 

        IDataResult<List<Account>> GetAll();
        IDataResult<List<AccountToGetDto> > GetByUserId(int userId);

        IResult BalanceDepositOrWithdraw(BalanceDepositOrWithDrawDto balanceDepositOrWithDrawDto );
        IDataResult<List<AccountSummaryDto>> GetAccountSummariesByUserId(int userId);
        IDataResult<List<AccountToSelect>> GetAccountsForSelectionByUserId(int userId);
    }
}
