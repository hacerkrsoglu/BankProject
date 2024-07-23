using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.AccountCard
{
    public class AccountCardDto :IDto
    {
        public int AccountId { get; set; }
        public int CreditCardId { get; set; }
    }
}
