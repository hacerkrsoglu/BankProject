﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Currency : IEntity
    {
        public int Id { get; set; }
        public string CurrencyType { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
