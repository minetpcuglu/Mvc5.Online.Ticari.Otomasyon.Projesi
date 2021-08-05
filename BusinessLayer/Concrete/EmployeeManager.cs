using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void EmployeeAdd(Employee employee)
        {
            _employeeDal.Insert(employee);
        }

        public void EmployeeDelete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public void EmployeeUpdate(Employee employee)
        {
            _employeeDal.Update(employee);
        }

        public Employee GetById(int id)
        {
           return _employeeDal.Get(x => x.EmployeeId == id);
        }

      

        public List<Employee> GetList()
        {
            return _employeeDal.List();
        }

        public List<Employee> GetListDepartmantID(int id)
        {
            return _employeeDal.List(x => x.DepartmantId==id);
        }
    }
}
