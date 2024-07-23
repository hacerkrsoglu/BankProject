using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CreditCard
{
    public class CreditCardToAddDto
    {
        public int UserId { get; set; }

        public string CardNumber { get; set; }//uniq
        public string CVV { get; set; }
        public DateTime ExpiryDate { get; set; }//SON kullanım
    }
}
