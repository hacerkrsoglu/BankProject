using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Transaction
{
    public class TransactionDto : IDto 
    {
        public int AccountId { get; set; }
        public int Id { get; set; }
        public int SenderAccountId { get; set; } //gönderen
        public int ReceiverAccountId { get; set; } //alan
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }

   
    }
}
