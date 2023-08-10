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
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soy adını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");

        }
    }
}
