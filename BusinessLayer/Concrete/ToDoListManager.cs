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
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public ToDoList GetById(int id)
        {
            return _toDoListDal.Get(x => x.ToDoListId == id);
        }

        public List<ToDoList> GetList()
        {
            return _toDoListDal.List();
        }

        public List<ToDoList> GetListTodoListId(int id)
        {
            return _toDoListDal.List(x => x.ToDoListId == id);
        }

        public void ToDoListAdd(ToDoList toDoList)
        {
            _toDoListDal.Insert(toDoList);
        }

        public void ToDoListdelete(ToDoList toDoList)
        {
            _toDoListDal.Delete(toDoList);
        }

        public void UpdateToDoList(ToDoList toDoList)
        {
            _toDoListDal.Update(toDoList);
        }
    }
}
