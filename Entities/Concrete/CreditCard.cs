using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }

        public int UserId {  get; set; }
        public string CardNumber{ get; set; }//uniq
        public string CVV { get; set; }
        public DateTime ExpiryDate { get; set; }//SON kullanım


        public User User { get; set; }//bir kartın bir kullanıcısı olur
        public AccountCard Account { get; set; }
    }
    
}
