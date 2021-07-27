using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ISalesMovementsService
    {
        void SalesMovementDelete(SalesMovements salesMovements);
        void SalesMovementUpdate(SalesMovements salesMovements);
        void SalesMovementAdd(SalesMovements salesMovements);
        List<SalesMovements> GetListEmployeeID(int id); //şartlı listeleme
        List<SalesMovements> GetListCurrentID(int id); //şartlı listeleme
        List<SalesMovements> GetList();
        //List<Product> GetListStatus();
        SalesMovements GetById(int id);
    }
}
