using Entities.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.User
{
    public class UserToAddValidator:AbstractValidator<UserToAdd>
    {

        public UserToAddValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz")
                .Length(3, 50).WithMessage("İsim en az 3, en fazla 50 karakter olmalıdır.")
                .Matches("^[a-zA-ZğüşöçıİĞÜŞÖÇ]+$").WithMessage("İsim sadece harf karakterleri içermelidir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz")
                .Length(2, 50).WithMessage("Soyisim en az 2, en fazla 50 karakter olmalıdır.")
                .Matches("^[a-zA-ZğüşöçıİĞÜŞÖÇ]+$").WithMessage("Soyisim sadece harf karakterleri içermelidir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");


            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.")
            .MaximumLength(20).WithMessage("Şifre en fazla 20 karakter olmalıdır.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,20}$")
                .WithMessage("Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("TC kimlik numarası boş olamaz");
        }

    }
}
