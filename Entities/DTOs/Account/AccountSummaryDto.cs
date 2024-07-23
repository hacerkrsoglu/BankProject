using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Account
{
    public class AccountSummaryDto : IDto
    {

        public string AccountNo { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string CreateDate { get; set; }
        public string[] AccountSummary { get; set; }


    }
}
