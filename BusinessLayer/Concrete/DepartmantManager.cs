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
    public class DepartmantManager : IDepartmantService
    {
        IDepartmantDal _departmantDal;
     

       
        public DepartmantManager(IDepartmantDal departmantDal)
        {
            _departmantDal = departmantDal;
        }

        public void DepartmantAdd(Departmant departmant)
        {
            departmant.DepartmantStatus = true;
            _departmantDal.Insert(departmant);
        }

        public void DepartmantDelete(Departmant departmant)
        {
         
            _departmantDal.Update(departmant);
        }

        public void DepartmantUpdate(Departmant departmant)
        {
            _departmantDal.Update(departmant);
        }

        public Departmant GetById(int id)
        {
          return  _departmantDal.Get(x => x.DepartmantId == id);
        }

        public List<Departmant> GetDepartmanDtoList()
        {
            return _departmantDal.List();
        }

        public List<Departmant> GetList()
        {
            return _departmantDal.List().Where(x => x.DepartmantStatus == true).ToList();
        }
    }
}
