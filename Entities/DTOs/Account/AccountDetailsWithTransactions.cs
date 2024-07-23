using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs.Account
{
    public class AccountDetailsWithTransactions : IDto
    {
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public DateTime CreateDate { get; set; }
        public Concrete.Transaction[] Transactions { get; set; }
    }
}
