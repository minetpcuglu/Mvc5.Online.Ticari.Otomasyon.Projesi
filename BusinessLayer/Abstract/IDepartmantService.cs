using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IDepartmantService
    {
        void DepartmantDelete(Departmant departmant);
        void DepartmantUpdate(Departmant departmant);
        void DepartmantAdd(Departmant departmant);
        List<Departmant> GetList();
        List<Departmant> GetDepartmanDtoList();
      
        Departmant GetById(int id);
    }
}
