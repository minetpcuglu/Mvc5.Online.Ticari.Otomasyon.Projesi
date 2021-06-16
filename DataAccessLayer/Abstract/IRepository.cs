﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
  public  interface IRepository<T>
    {
        List<T> List();
        List<T> List(Expression<Func<T, bool>> filter);  //Şartlı listeleme 

        T Get(Expression<Func<T, bool>> filter);  //dışarıdann bir şart alıcak
        void Insert(T p);
        void Delete(T p);
        void Update(T p);
    }
}
