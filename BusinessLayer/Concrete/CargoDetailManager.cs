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
    public class CargoDetailManager : ICargoDetailService
    {
        ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void CargoDetailAdd(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Insert(cargoDetail);
        }

        public void CargoDetaildelete(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Delete(cargoDetail);
        }

        public CargoDetail GetById(int id)
        {
           return _cargoDetailDal.Get(x => x.CargoDetailId == id);
        }

        public List<CargoDetail> GetList()
        {
           return _cargoDetailDal.List();
        }

        public void UpdateCargoDetail(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Update(cargoDetail);
        }
    }
}
