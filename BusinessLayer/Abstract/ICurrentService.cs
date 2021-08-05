using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICurrentService
    {
        List<Current> GetList();
        void CurrentAdd(Current current);

        void DeleteCurrent(Current current); 
        Current GetById(int id);  

        void UpdateCurrent(Current current); 

        Current GetByName(string name); 
        Current GetCurrent(string username, string password);
    }
}
