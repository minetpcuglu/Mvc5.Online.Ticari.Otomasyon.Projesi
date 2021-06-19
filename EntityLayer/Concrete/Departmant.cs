using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Departmant
    {
        [Key]
        public int DepartmantId { get; set; } //bölüm

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmantName { get; set; }
        public bool DepartmantStatus { get; set; }
     


        //ilişkiler

        public ICollection<Employee> Employees { get; set; }

    }
}