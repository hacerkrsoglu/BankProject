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
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            // User kaydı silindiğinde, o kullanıcıya ait tüm Account
            // kayıtlarının da silinmesini istiyorsanız

            builder
                .HasIndex(x => x.IBAN)
                .IsUnique();
            builder
                .HasIndex(x => x.AccountNo)
                .IsUnique();

            builder
                .HasOne(x => x.AccountPurpose)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.AccountPurposeId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(x => x.Currency)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(x => x.AccountType)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.AccountTypeId)
                .OnDelete(DeleteBehavior.Restrict);





        }
    }
}
