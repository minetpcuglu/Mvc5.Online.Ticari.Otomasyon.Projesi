using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; } //fatura

        [Column(TypeName = "Char")]
        [StringLength(15)]
        public string BillSerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string BillSıraNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TaxAdministration { get; set; } //vergi dairesi

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliveryarea { get; set; } //Teslim alan

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; } //Teslim Eden

        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }


        //ilişkiler 1-n
        public ICollection<BillPen> billPens { get; set; }





    }
}