using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;
        IUserDal _userDal;

        public AccountManager(IAccountDal accountDal, IUserDal userDal)
        {
            _accountDal = accountDal;
            _userDal = userDal;
        }

        public IResult Add(AccountToAdd accountToAdd)
        {
            var userToCheck = _userDal.Get(u => u.Id == accountToAdd.UserId);
            if (userToCheck == null)
            {
                return new ErrorResult("Kullanıcı bulunamadı");
                
            }

            //var random = new Random();
            //string iban = random.Next(100000, 999999).ToString();
            ////veritabanında bu sayının olup olmadığını kontrol etmem lazım.
            //var isUnique = !_accountDal.IsIBANExists(iban);
            //if (isUnique == true)
            //{
            //    return new Result(false, "Bu iban numarası zaten  var");

            //}

            var iban = Guid.NewGuid().ToString();

            var accountNo = Guid.NewGuid().ToString();
            var account = new Account
            {
                UserId = accountToAdd.UserId,
                AccountPurposeId = accountToAdd.AccountPurposeId,
                AccountTypeId = accountToAdd.AccountTypeId,
                CreateDate = DateTime.Now,
                CurrencyId = accountToAdd.CurrencyId,
                IBAN = iban,
                AccountNo = accountNo
                


            };


            _accountDal.Add(account);
            return new SuccessResult("Hesap başarıyla oluşturuldu");
        }

        public IResult BalanceDepositOrWithdraw(BalanceDepositOrWithDrawDto balanceDepositOrWithDrawDto)
        {
            var accountToCheck = _accountDal.Get(x =>x.Id == balanceDepositOrWithDrawDto.AccountId);
            if (accountToCheck == null)
            {
                return new ErrorResult("Hesap bulunamadı");

            }
            if (balanceDepositOrWithDrawDto.TypeId == 1)
            {
                if (accountToCheck.Balance < balanceDepositOrWithDrawDto.Balance)
                {
                    return new ErrorResult("Fakirsiniz..");
                }

                accountToCheck.Balance -= balanceDepositOrWithDrawDto.Balance;
                
            }
            if (balanceDepositOrWithDrawDto.TypeId == 2)
            {
                accountToCheck.Balance += balanceDepositOrWithDrawDto.Balance;
                
            }

            _accountDal.Update(accountToCheck);
            return new SuccessResult("Balance değeri güncellendi");
        }

        public IResult Delete(int accountId)
        {
            var accountToCheck = _accountDal.Get(u => u.Id == accountId);
            if (accountToCheck == null)
            {
                return new ErrorResult("Hesap bulunamadı");

            }
            _accountDal.Delete(accountToCheck);
            return new SuccessResult("Hesap başarıyla silindi");
        }

        public IDataResult<List<AccountToSelect>> GetAccountsForSelectionByUserId(int userId)
        {
            var userToCheck = _userDal.GetUserById(userId);

            if (userToCheck == null)
            {
                return new ErrorDataResult<List<AccountToSelect>>("Kullanıcı bulunamadı");
            }

            var result = _accountDal.GetAccountsForSelectByUserId(userId);

            return new SuccessDataResult<List<AccountToSelect>>(result);
        }

        public IDataResult<List<AccountSummaryDto>> GetAccountSummariesByUserId(int userId)
        {
            var userToCheck = _userDal.GetUserById(userId);

            if (userToCheck == null)
            {
                return new ErrorDataResult<List<AccountSummaryDto>>("Kullanıcı bulunamadı");
            }

            var summaryResult = _accountDal.GetSummaryByUserId(userId);
            List<AccountSummaryDto> resultToReturn = new();

            foreach (var accountSummaryDto in summaryResult)
            {
                List<string> summaries = new();

                foreach (var item in accountSummaryDto.Transactions)
                {
                    var recieverAccount = _accountDal.Get(x => x.Id == item.ReceiverAccountId);
                    var currency = "";


                    switch (item.SenderAccount.CurrencyId)
                    {
                        case 1:
                            currency = "TL";
                            break;
                        case 2:
                            currency = "USD";
                            break;
                        case 3:
                            currency = "EURO";
                            break;

                        default:
                            break;
                    }

                    summaries.Add($@"{ item.SenderAccount?.AccountNo } hesap numarasına sahip hesaptan { recieverAccount?.AccountNo } hesap numarasına sahip hesaba { item?.Amount } {currency} para transfer edilmiştir.");
                }

                resultToReturn.Add(new()
                {
                    AccountNo = accountSummaryDto.AccountNo,
                    AccountSummary = summaries.ToArray(),
                    Balance = accountSummaryDto.Balance,
                    CreateDate = accountSummaryDto.CreateDate.ToString("dd.MM.yyyy"),
                    Currency = accountSummaryDto.Currency
                });
            }

            return new SuccessDataResult<List<AccountSummaryDto>>(resultToReturn);
        }

        public IDataResult<List<Account>> GetAll()
        {
            return new SuccessDataResult<List<Account>>(_accountDal.GetAll(), "Hesaplar listelendi");
        }

        public IDataResult<List<AccountToGetDto>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<AccountToGetDto>>(_accountDal.GetByUserId(userId), "Hesaplar listelendi");

        }

        public IDataResult<Account> UpdateAccount(AccountToUpdate accountToUpdate)
        {
            var account = _accountDal.Get(a => a.Id == accountToUpdate.Id);
            if (account == null)
            {
                return new ErrorDataResult<Account>("Hesap bulunamadı");
                
            }

            account.AccountTypeId = accountToUpdate.AccountTypeId;
            account.CurrencyId = accountToUpdate.CurrencyId;
            account.CurrencyId = accountToUpdate.AccountPurposeId;



            _accountDal.Update(account);
            return new SuccessDataResult<Account>("Hesap bilgileri güncellendi");
        }

       
    }
}
