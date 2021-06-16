using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }  //gider

        [Column(TypeName = "Varchar")]
        [StringLength(310)]
        public string Description { get; set; }
        public DateTime date { get; set; }
        public decimal Amount { get; set; }   //tutar 



    }
}