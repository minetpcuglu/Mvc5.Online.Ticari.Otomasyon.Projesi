using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short UnitInStok { get; set; }
        public decimal UnitPrice { get; set; }    //AlışFiyatı
        public decimal SalePrice { get; set; }    //satış fiyatı
        public bool Status { get; set; }          //durum

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string PImage { get; set; }

        //ilişkiler 
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

       public ICollection<SalesMovements> Sales { get; set; }

    }
}