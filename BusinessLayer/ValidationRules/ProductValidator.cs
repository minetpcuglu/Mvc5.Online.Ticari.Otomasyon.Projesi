using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş geçilemez");

            RuleFor(x => x.Brand).NotEmpty().WithMessage("Marka Bilgisi Boş geçilemez");

            RuleFor(x => x.PImage).NotEmpty().WithMessage("Resim Linki  boş geçilemez");

            RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("Ürün İsmi en az 3 Karakter içermelidir");

            RuleFor(x => x.Brand).MinimumLength(2).WithMessage("Marka İsmi en az 2 Karakter içermelidir");

            //RuleFor(x => x.SalePrice.ToString()).NotEmpty().WithMessage("Lütfen alış fiyat girişi yapınız");

            //RuleFor(x => x.UnitPrice.ToString()).NotEmpty().WithMessage("Lütfen Satış fiyat girişi yapınız");

            //RuleFor(x => x.UnitPrice.ToString()).Length(1, 10).WithMessage("Lütfen üçret girişi yapınız");
            //RuleFor(x => x.UnitPrice.ToString()).Length(1,10).WithMessage("Lütfen satış fiyat girişi yapınız");

            //RuleFor(x => x.UnitInStok.ToString()).NotEmpty().WithMessage("Stok girişi yapınız");
        }
    }
}
