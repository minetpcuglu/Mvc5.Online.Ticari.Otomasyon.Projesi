using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class ProductDetails
    {
        [Key]
        public int DetailId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(3000)]
        public string ProductDescription { get; set; }
    }
}
