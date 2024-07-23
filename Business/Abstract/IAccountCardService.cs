using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Account;
using Entities.DTOs.AccountCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountCardService
    {
        IResult UpdateAccountCard(AccountCardDto accountCardDto);
        IResult DeleteAccountCard(int accountId, int creditCardId);

    }
}
