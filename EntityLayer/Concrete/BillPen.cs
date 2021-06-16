using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class BillPen
    {
        [Key]
        public int BillPenId { get; set; } //fatura kalem

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public int Piece { get; set; }  //adet
        public decimal UnitPrice { get; set; }  //Birim fiyat
        public decimal Amount { get; set; }  //tutar

        //ilişkiler 
        public int  BillId { get; set; }
        public virtual Bill Bill { get; set; }



    }
}