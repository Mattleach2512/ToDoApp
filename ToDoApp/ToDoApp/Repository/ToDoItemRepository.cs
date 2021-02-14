using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Contracts;
using ToDoApp.Data;

namespace ToDoApp.Repository
{
    public class ToDoItemRepository : IToDoRepository
    {

        private readonly ApplicationDbContext _db;

        public ToDoItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        

        public bool Create(ToDoItem entity)
        {
            _db.ToDoItems.Add(entity);
            return Save();
        }

        public bool Delete(ToDoItem entity)
        {
            _db.ToDoItems.Remove(entity);
            return Save();
        }

        public List<ToDoItem> FindAll()
        {
            return _db.ToDoItems.ToList();

        }

        public ToDoItem FindById(int Id)
        {
            return _db.ToDoItems.Find(Id);

        }

        public bool isExists(int Id)
        {
            var exists = _db.ToDoItems.Any(q => q.Id == Id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(ToDoItem entity)
        {
            _db.ToDoItems.Update(entity);
            return Save();
        }
    }
}
