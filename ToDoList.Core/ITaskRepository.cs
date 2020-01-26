using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models.Models;

namespace ToDoList.Core
{
    public interface ITaskRepository
    {
        void Insert(Task Task);
        void Update(Task Task);
        void Delete(Task Task);
        List<Task> SelectAll();
        Task getSingle(int id);
    }
}