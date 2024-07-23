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
    public class CrediCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.CreditCards)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);// User kaydı silindiğinde, o kullanıcıya ait tüm CreditCard kayıtlarının da silinmesi için 

            builder
                .HasIndex(x => x.CardNumber)
                .IsUnique();

         

         
                
            
        }
    }
}
