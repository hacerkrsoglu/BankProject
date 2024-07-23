using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CreditCard
{
    public class CreditCardToGet :IDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string CardNumber { get; set; }//uniq
    }
}
