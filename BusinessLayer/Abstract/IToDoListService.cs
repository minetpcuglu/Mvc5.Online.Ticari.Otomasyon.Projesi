using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IToDoListService
    {
        List<ToDoList> GetList();
        void ToDoListAdd(ToDoList toDoList);//categoryden eklemek için bir tanım yapıldı

        ToDoList GetById(int id);  //dısarıdan bir ıd alıcak
        List<ToDoList> GetListTodoListId(int id); //şartlı listeleme

        void ToDoListdelete(ToDoList toDoList); //silme işlemi

        void UpdateToDoList(ToDoList toDoList); //güncelleme işlemi 
    }
}
