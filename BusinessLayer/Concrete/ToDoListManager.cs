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
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListManager(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public void TAdd(ToDoList t)
        {
            _toDoListRepository.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _toDoListRepository.Delete(t);
        }

        public ToDoList TGetById(int id)
        {
            return _toDoListRepository.GetById(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListRepository.GetList();
        }

        public List<ToDoList> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList t)
        {
            _toDoListRepository.Update(t);
        }
    }
}
