using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Account
{
    public class AccountToAdd :IDto
    {
       
        public int UserId { get; set; }//bunu oluşturmama gerek yok navigation property tanımlasam yeterli

        public int AccountPurposeId { get; set; }//açılış amacı
        public int CurrencyId { get; set; }//para birimi
        public int AccountTypeId { get; set; }


    }
}
