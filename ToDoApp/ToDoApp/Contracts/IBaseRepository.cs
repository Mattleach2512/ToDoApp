using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Contracts
{
    public interface IBaseRepository<T> where T : class
    {

        List<T> FindAll();

        T FindById(int Id);

        bool Create(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        bool Save();
        bool isExists(int Id);


    }
}
