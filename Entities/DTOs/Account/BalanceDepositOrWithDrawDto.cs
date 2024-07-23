using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Account
{
    public class BalanceDepositOrWithDrawDto :IDto
    {
        public int AccountId { get; set; }
        public int TypeId { get; set; }
        public decimal Balance { get; set; }

    }
}
