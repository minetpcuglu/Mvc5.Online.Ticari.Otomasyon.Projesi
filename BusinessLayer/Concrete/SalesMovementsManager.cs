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
    public class SalesMovementsManager : ISalesMovementsService
    {
        ISalesMovementsDal _salesMovementsDal;

        public SalesMovementsManager(ISalesMovementsDal salesMovementsDal)
        {
            _salesMovementsDal = salesMovementsDal;
        }

        public SalesMovements GetById(int id)
        {
           return _salesMovementsDal.Get(x => x.SalesMovementsId == id);
        }

        public List<SalesMovements> GetList()
        {
          return  _salesMovementsDal.List();
        }

        public List<SalesMovements> GetListCurrentID(int id)
        {
            return _salesMovementsDal.List(x => x.CurrentId == id);
            
        }

        public List<SalesMovements> GetListEmployeeID(int id)
        {
          return  _salesMovementsDal.List(x => x.EmployeeId == id);
        }

        public void SalesMovementAdd(SalesMovements salesMovements)
        {
            _salesMovementsDal.Insert(salesMovements);
        }

        public void SalesMovementDelete(SalesMovements salesMovements)
        {
            _salesMovementsDal.Delete(salesMovements);
        }

        public void SalesMovementUpdate(SalesMovements salesMovements)
        {
            _salesMovementsDal.Update(salesMovements);
        }
    }
}
