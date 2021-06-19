using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
   public class DepartmantDetailDto:IDto
    {
        public int DepartmanId { get; set; }
        public int  EmployeeId { get; set; }
        public string DepartmantName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EImage { get; set; }
    }
}
