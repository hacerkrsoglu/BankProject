using Core.Entities;

namespace Entities.DTOs.Transaction
{
    public class TransactionToAdd : IDto
    {
        public int SenderAccountId { get; set; }
        public int RecieverAccountId { get; set; }
        public string IBAN { get; set; }
        public decimal Amount { get; set; }
    }
}
