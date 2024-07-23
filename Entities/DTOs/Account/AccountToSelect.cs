using Core.Entities;

namespace Entities.DTOs.Account
{
    public class AccountToSelect : IDto
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
    }
}
