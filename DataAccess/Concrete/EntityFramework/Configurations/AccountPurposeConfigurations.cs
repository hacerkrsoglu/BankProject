using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AccountPurposeConfigurations : IEntityTypeConfiguration<AccountPurpose>
    {
        public void Configure(EntityTypeBuilder<AccountPurpose> builder)
        {
            builder
                .HasData(new List<AccountPurpose>()
                {
                    new() { Id = 1, Name = "Şahsi Hesap" },
                    new() { Id = 2, Name = "Kurumsal Hesap" },
                });
        }
    }
}
