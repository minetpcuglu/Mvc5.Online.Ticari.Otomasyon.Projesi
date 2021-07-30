using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBillPenService
    {
        List<BillPen> GetList();
        void BillPenAdd(BillPen billPen);//categoryden eklemek için bir tanım yapıldı

        BillPen GetById(int id);  //dısarıdan bir ıd alıcak
        List<BillPen> GetListBillID(int id); //şartlı listeleme

        void BillPendelete(BillPen billPen); //silme işlemi

        void UpdateBillPen(BillPen billPen); //güncelleme işlemi 
    }
}
