using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AccountTypeConfig : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasData(new List<AccountType>()
            {
                new() { Id = 1, Name = "Vadeli Hesap" },
                new() { Id = 2, Name = "Vadesiz Hesap" },
            });
        }
    }
}
