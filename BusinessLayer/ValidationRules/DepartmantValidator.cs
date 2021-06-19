using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class DepartmantValidator:AbstractValidator<Departmant>
    {
        public DepartmantValidator()
        {
            RuleFor(x => x.DepartmantName).NotEmpty().WithMessage("Departman İsmi Boş geçilemez");
            RuleFor(x => x.DepartmantName).MinimumLength(3).WithMessage("Departman İsmi en az 3 Karakter içermelidir");
            RuleFor(x => x.DepartmantName).MaximumLength(30).WithMessage("Departman ismi en fazla 30 karakter içermelidir");
        }
       
    }
}
