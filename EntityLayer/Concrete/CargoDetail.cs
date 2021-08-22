using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }

        [Column(TypeName = "Varchar")]
        public string  Description { get; set; }

        [Column(TypeName = "Varchar")]
        public string TrackingCode { get; set; }
        public string Employee { get; set; }
        public string ReceiverName { get; set; }
        public DateTime Date { get; set; }
    }
}
