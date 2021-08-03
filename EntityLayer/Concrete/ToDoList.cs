using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Heading { get; set; }

        [Column(TypeName = "bit")]
     
        public bool  Status { get; set; }
    }
}
