using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int GenderId { get; set; }//cinsiyet
        
       
        public string CustomerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public Gender Gender { get; set; }
        public ICollection<Account> Accounts { get; set; }//bir kullanıcını birden çok hesabı var.
        public ICollection<CreditCard> CreditCards { get; set; }




    }
}
