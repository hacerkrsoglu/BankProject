using Entities.Concrete;
using Entities.DTOs.Account;
using Entities.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Account
{
    public class AccountToUpdateValidator : AbstractValidator<AccountToUpdate>
    {
        //constructor oluştururuz
        public AccountToUpdateValidator()
        {
            RuleFor(x => x.AccountTypeId)
            .NotEmpty().WithMessage("Hesap tipi boş olmamalı")
            .GreaterThan(0).WithMessage("Geçersiz hesap tipi");


            RuleFor(x => x.AccountPurposeId)
            .NotEmpty().WithMessage("Hesap açalış amacı olmamalı")
            .GreaterThan(0).WithMessage("Geçersiz hesap açılış amacı");


            RuleFor(x => x.AccountTypeId)
           .NotEmpty().WithMessage("Para birimi boş olmalı")
           .GreaterThan(0).WithMessage("Geçersiz para birimi");
            //GreaterThan kullandım çünkü bu sayı değişiklik gösterebilir buna uyum sağlaması için

        }

    }
}
