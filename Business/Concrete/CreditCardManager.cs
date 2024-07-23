using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Account;
using Entities.DTOs.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCardToAddDto creditCardToAddDto)
        {
            var creditCard = new CreditCard
            {
                UserId = creditCardToAddDto.UserId,
                CardNumber = creditCardToAddDto.CardNumber,
                CVV = creditCardToAddDto.CVV,
                ExpiryDate = creditCardToAddDto.ExpiryDate
            };

            _creditCardDal.Add(creditCard);
            return new SuccessResult("Credit card added successfully");
        }

        public IResult Delete(int creditCardId)
        {
            var creditCard = _creditCardDal.Get(c => c.Id == creditCardId);
            if (creditCard == null)
            {
                return new ErrorResult("Credit card not found");
            }

            _creditCardDal.Delete(creditCard);
            return new SuccessResult("Credit card deleted successfully");
        }
        public IResult Update(CreditCardToUpdateDto creditCardToUpdateDto)
        {
            var creditCard = _creditCardDal.Get(c => c.Id == creditCardToUpdateDto.Id);
            if (creditCard == null)
            {
                return new ErrorResult("Credit card not found");
            }

            creditCard.CardNumber = creditCardToUpdateDto.CardNumber;
            creditCard.CVV = creditCardToUpdateDto.CVV;
            creditCard.ExpiryDate = creditCardToUpdateDto.ExpiryDate;

            _creditCardDal.Update(creditCard);
            return new SuccessResult("Credit card updated successfully");
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            var result = _creditCardDal.GetAll();
            return new SuccessDataResult<List<CreditCard>>(result, "Credit cards listed successfully");
        }

        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            var result = _creditCardDal.Get(c => c.Id == creditCardId);
            return new SuccessDataResult<CreditCard>(result, "Credit card retrieved successfully");
        }

        public IDataResult<List<CreditCardToGet>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<CreditCardToGet>>(_creditCardDal.GetByUserId(userId), "Kartlar listelendi");



        }
    }
}
