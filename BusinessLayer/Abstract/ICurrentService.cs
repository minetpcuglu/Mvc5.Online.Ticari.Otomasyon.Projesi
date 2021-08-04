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
        void CurrentAdd(Current current);//Cari eklemek için bir tanım yapıldı

        void DeleteCurrent(Current current); //silme işlemi 
        Current GetById(int id);  //dısarıdan bir ıd alıcak 

        void UpdateCurrent(Current current); //güncelleme işlemi 

        Current GetByName(string name); //dısarıdan bir isim alıcak
        Current GetCurrent(string username, string password);
    }
}
