using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Account
{
    public class AccountToUpdate
    {
     
        public int Id { get; set; }
        public int AccountPurposeId { get; set; }//açılış amacı
        public int CurrencyId { get; set; }//para birimi
        public int AccountTypeId { get; set; }
     
    }
}
