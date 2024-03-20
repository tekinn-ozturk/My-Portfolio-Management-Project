using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    //AbstractValidator<> sınıfı inherit verilir.
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        //Kısıtlamalar ctor içerisinde yazılır.
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Proje Adı Boş Geçilemez!");
            RuleFor(x=>x.ImageUrl).NotEmpty().NotNull().WithMessage("Görsel-1 Boş Geçilemez!");
            RuleFor(x=>x.ImageUrl2).NotEmpty().NotNull().WithMessage("Görsel-2 Boş Geçilemez!");
            RuleFor(x=>x.Price).NotEmpty().NotNull().WithMessage("Fiyat Boş Geçilemez!");
            RuleFor(x=>x.Value).NotEmpty().NotNull().WithMessage("Değer Boş Geçilemez!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje Adı en az 5 karakterden oluşmak zorundadır!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje Adı en fazla 100 karakterden oluşabilir!");

        }
    }
}
