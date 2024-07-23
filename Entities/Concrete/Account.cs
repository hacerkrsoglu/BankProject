using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Account:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }//bunu oluşturmama gerek yok navigation property tanımlasam yeterli
        public int  AccountPurposeId { get; set; }//açılış amacı
        public int CurrencyId { get; set; }//para birimi
        public int AccountTypeId { get; set; }
        public DateTime CreateDate { get; set; }//açılış tarih
        public string IBAN { get; set; }//uniq
        public decimal Balance { get; set; }
        public string AccountNo { get; set; }



        public User User { get; set; }//navigation property Bir hesabın bir kullanıcısı var
        public AccountType AccountType { get; set; }
        public AccountPurpose AccountPurpose { get; set; }
        public Currency Currency { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public AccountCard Card { get; set; }
    }
}
