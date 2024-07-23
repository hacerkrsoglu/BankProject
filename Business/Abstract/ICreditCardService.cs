using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Account;
using Entities.DTOs.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCardToAddDto creditCardToAddDto);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int creditCardId);
        IResult Update(CreditCardToUpdateDto creditCardToUpdateDto);
        IResult Delete(int creditCardId);
        IDataResult<List<CreditCardToGet>> GetByUserId(int userId);


    }
}
