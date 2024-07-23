using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountCardManager : IAccountCardService
    {
        IAccountCardDal _accountCardDal;

        public AccountCardManager(IAccountCardDal accountCardDal)
        {
            _accountCardDal = accountCardDal;
        }

        public IResult DeleteAccountCard(int accountId, int cardId)
        {
            var dataToDelete = _accountCardDal.GetByAccountIdOrCreditCardId(accountId, cardId);

            if (dataToDelete == null)
            {
                return new ErrorResult("Kayıt Bulunamadı");
            }

            _accountCardDal.Delete(dataToDelete);
            return new SuccessResult("Başarılı");
        }

        public IResult UpdateAccountCard(AccountCardDto accountCardDto)
        {
            var dataToUpdate = _accountCardDal.GetByAccountIdOrCreditCardId(accountCardDto.AccountId,accountCardDto.CreditCardId);

            if (dataToUpdate == null)
            {
                _accountCardDal.Add(new()
                {
                    AccountId = accountCardDto.AccountId,
                    CreditCardId = accountCardDto.CreditCardId,
                });

                return new SuccessResult("Başarılı");
                
            }

            dataToUpdate.CreditCardId = accountCardDto.CreditCardId;


         

            _accountCardDal.Update(dataToUpdate);
            return new SuccessResult("Güncelleme başarılı.");


        }
    }
}
