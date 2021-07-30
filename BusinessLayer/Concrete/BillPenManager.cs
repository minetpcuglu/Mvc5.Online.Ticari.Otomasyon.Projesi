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
  public  class BillPenManager:IBillPenService
    {
        IBillPenDal _billPenDal;

        public BillPenManager(IBillPenDal billPenDal)
        {
            _billPenDal = billPenDal;
        }

        public void BillPenAdd(BillPen billPen)
        {
            _billPenDal.Insert(billPen);
        }

        public void BillPendelete(BillPen billPen)
        {
            _billPenDal.Delete(billPen);
        }

        public BillPen GetById(int id)
        {
           return _billPenDal.Get(x => x.BillId == id);
        }

        public List<BillPen> GetList()
        {
            return _billPenDal.List();
        }

        public List<BillPen> GetListBillID(int id)
        {
            return _billPenDal.List(x => x.BillId == id);
        }

        public void UpdateBillPen(BillPen billPen)
        {
            _billPenDal.Update(billPen);
        }
    }
}
