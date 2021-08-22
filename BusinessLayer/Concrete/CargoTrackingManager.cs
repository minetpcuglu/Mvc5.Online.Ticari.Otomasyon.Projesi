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
    public class CargoTrackingManager : ICargoTrackingService
    {
        ICargoTrackingDal _cargoTrackingDal;

        public CargoTrackingManager(ICargoTrackingDal cargoTrackingDal)
        {
            _cargoTrackingDal = cargoTrackingDal;
        }


        public void CargoTrackingAdd(CargoTracking cargoTracking)
        {
            _cargoTrackingDal.Insert(cargoTracking);
        }

        public void CargoTrackingdelete(CargoTracking cargoTracking)
        {
            _cargoTrackingDal.Delete(cargoTracking);
        }

        public CargoTracking GetById(int id)
        {
            return _cargoTrackingDal.Get(x => x.CargoTrackingId == id);
        }

        public List<CargoTracking> GetList()
        {
           return _cargoTrackingDal.List();
        }

        public List<CargoTracking> GetListCargoDetail(string id)
        {
            return _cargoTrackingDal.List(x => x.TrackingCode == id).ToList();
        }

        public void UpdateCargoTracking(CargoTracking cargoTracking)
        {
            _cargoTrackingDal.Update(cargoTracking);
        }
    }
}
