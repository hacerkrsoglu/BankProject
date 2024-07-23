using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CreditCard
{
    public class CreditCardToUpdateDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } // Unique
        public string CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
