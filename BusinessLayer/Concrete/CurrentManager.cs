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
    public class CurrentManager : ICurrentService
    {
        ICurrentDal _currentDal;

        public CurrentManager(ICurrentDal currentDal)
        {
            _currentDal = currentDal;
        }

        public void CurrentAdd(Current current)
        {
            current.CurrentStatus = true;
            _currentDal.Insert(current);
        }

        public void DeleteCurrent(Current current)
        {
            _currentDal.Update(current);
        }

        public Current GetById(int id)
        {
            return _currentDal.Get(x => x.CurrentId == id);
        }

        public Current GetByName(string name)
        {
            return _currentDal.Get(x => x.CurrentName == name);
        }

        public List<Current> GetList()
        {
            return _currentDal.List(x=>x.CurrentStatus==true).ToList();
        }

        public void UpdateCurrent(Current current)
        {
            _currentDal.Update(current);
        }
    }
}
