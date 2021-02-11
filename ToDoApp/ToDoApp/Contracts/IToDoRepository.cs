using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;

namespace ToDoApp.Contracts
{
    public interface IToDoRepository : IBaseRepository<ToDoItem>
    {
    }
}
