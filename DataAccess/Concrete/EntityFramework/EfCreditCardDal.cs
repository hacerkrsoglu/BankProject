using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, PostgreSqlContext>, ICreditCardDal
    {
        public List<CreditCardToGet> GetByUserId(int userId)
        {
            using (PostgreSqlContext context = new PostgreSqlContext())
            {
                return context.Cards
                    .Where(x => x.UserId == userId)
                    .Select(x => new CreditCardToGet
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        CardNumber = x.CardNumber


                    })
                    .ToList();

            }
        }
    }
}
