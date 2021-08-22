using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICargoDetailService
    {
        List<CargoDetail> GetList();
        void CargoDetailAdd(CargoDetail cargoDetail);//categoryden eklemek için bir tanım yapıldı

        CargoDetail GetById(int id);  //dısarıdan bir ıd alıcak

        void CargoDetaildelete(CargoDetail cargoDetail); //silme işlemi

        void UpdateCargoDetail(CargoDetail cargoDetail); //güncelleme işlemi 
    }
}
