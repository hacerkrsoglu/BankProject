using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Account;
using Entities.DTOs.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {
        List<CreditCardToGet> GetByUserId(int userId);

    }
}
