using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Account
{
    public class AccountToGetDto :IDto
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }//bunu oluşturmama gerek yok navigation property tanımlasam yeterli
        public int AccountPurposeId { get; set; }//açılış amacı
        public int CurrencyId { get; set; }//para birimi
        public int AccountTypeId { get; set; }
        public string AccountPurposeName { get; set; }
        public string AccountCurrencyName { get; set; }
        public string AccountTypeName { get; set; }
        public string IBAN { get; set; }//uniq
        public decimal Balance { get; set; }
        public string AccountNo { get; set; }
        public int? CreditCardId { get; set; }
        public string CreditCardName { get;set; }


    }
}
