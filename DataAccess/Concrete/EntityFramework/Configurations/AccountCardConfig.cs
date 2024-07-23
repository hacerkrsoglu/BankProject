using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AccountCardConfig : IEntityTypeConfiguration<AccountCard>
    {
        public void Configure(EntityTypeBuilder<AccountCard> builder)
        {
            builder
                .HasIndex(x => x.AccountId)
                .IsUnique();
            builder
                .HasIndex(x => x.CreditCardId)
                .IsUnique();

            builder
              .HasOne(x => x.Account)
              .WithOne(x => x.Card)
              .HasForeignKey<AccountCard>(x => x.AccountId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.CreditCard)
                .WithOne(x => x.Account)
                .HasForeignKey<AccountCard>(x => x.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
