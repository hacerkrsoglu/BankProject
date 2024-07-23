using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder
                .HasData(new List<Currency>()
                {
                    new() { Id = 1, CurrencyType = "TL" },
                    new() { Id = 2, CurrencyType = "USD" },
                    new() { Id = 3, CurrencyType = "EURO" }
                });
        }
    }
}
