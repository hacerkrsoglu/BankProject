using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                 .HasOne(x => x.Gender)
                 .WithMany(x => x.Users)
                 .HasForeignKey(x => x.GenderId)
                 .OnDelete(DeleteBehavior.Restrict);


            builder

                .HasIndex(x => x.Email)//uniq yaptık 
                .IsUnique();

            builder

               .HasIndex(x => x.CustomerNo)//uniq yaptık 
               .IsUnique();


        }
    }
}
