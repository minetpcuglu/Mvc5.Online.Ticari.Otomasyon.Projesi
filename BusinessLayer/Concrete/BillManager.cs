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
    public class BillManager : IBillService
    {
        IBillDal _bilDal;

        public BillManager(IBillDal bilDal)
        {
            _bilDal = bilDal;
        }

        public void BillAdd(Bill bill)
        {
            _bilDal.Insert(bill);
        }

        public void Billdelete(Bill bill)
        {
            _bilDal.Delete(bill);
        }

        public Bill GetById(int id)
        {
           return _bilDal.Get(x => x.BillId == id);
        }

        public List<Bill> GetList()
        {
            return _bilDal.List();
        }

        public void UpdateBill(Bill bill)
        {
            _bilDal.Update(bill);
        }
    }
}
