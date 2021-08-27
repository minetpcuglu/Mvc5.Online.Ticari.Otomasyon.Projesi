using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
   public class CascadingProduct
    {
        public IEnumerable<SelectListItem> category { get; set; }
        public IEnumerable<SelectListItem> product { get; set; }
    }
}
