using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IEmployeeService
    {

        void EmployeeDelete(Employee employee);
        void EmployeeUpdate(Employee employee);
        void EmployeeAdd(Employee employee);
        List<Employee> GetList();

        List<Employee> GetListDepartmantID(int id); //şartlı listeleme

        Employee GetById(int id);
    }
}
