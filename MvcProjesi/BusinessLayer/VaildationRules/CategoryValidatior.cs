using BussinesLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.VaildationRules
{
    public class CategoryValidatior : AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");
        }
    }
}
