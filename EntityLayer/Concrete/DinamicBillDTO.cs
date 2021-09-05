using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class DinamicBillDTO
    {
        public IEnumerable<Bill> bills { get; set; }
        public IEnumerable<BillPen> billPens { get; set; }
    }
}
