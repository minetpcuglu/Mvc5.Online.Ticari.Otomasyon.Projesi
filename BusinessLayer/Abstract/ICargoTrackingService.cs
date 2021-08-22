using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICargoTrackingService
    {
        List<CargoTracking> GetList();
        void CargoTrackingAdd(CargoTracking cargoTracking);//categoryden eklemek için bir tanım yapıldı

       CargoTracking GetById(int id);  //dısarıdan bir ıd alıcak

        void CargoTrackingdelete(CargoTracking cargoTracking); //silme işlemi

        void UpdateCargoTracking(CargoTracking cargoTracking); //güncelleme işlemi 
        List<CargoTracking> GetListCargoDetail(string id);
    }
}
