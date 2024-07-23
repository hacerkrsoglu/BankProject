using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AccountCard:IEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CreditCardId { get; set; }


        public Account Account { get; set; }
        public CreditCard CreditCard { get; set; }

    }
}
