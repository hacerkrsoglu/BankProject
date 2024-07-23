using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class GenderConfigurations : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder
                .HasData(new List<Gender>()
                {
                    new() { Id = 1, GenderName = "Erkek" },
                    new() { Id = 2, GenderName = "Kadın" }
                });
        }
    }
}
