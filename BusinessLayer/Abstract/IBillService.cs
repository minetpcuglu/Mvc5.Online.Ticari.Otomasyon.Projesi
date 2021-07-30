using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public interface IBillService
    {
        List<Bill> GetList();
        void BillAdd(Bill bill);//categoryden eklemek için bir tanım yapıldı

        Bill GetById(int id);  //dısarıdan bir ıd alıcak

        void Billdelete(Bill bill); //silme işlemi

        void UpdateBill(Bill bill); //güncelleme işlemi 
    }
}
