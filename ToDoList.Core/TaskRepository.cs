using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models.Models;

namespace ToDoList.Core
{
    public class TaskRepository : ITaskRepository
    {
        DataContext entity = new DataContext();
        public void Insert(Task Task)
        {
            entity.Tasks.Add(Task);
            entity.SaveChanges();
        }

        public void Update(Task Task)
        {
            Task item = entity.Tasks.Where(id => id.Id == Task.Id).First();
            item.Name = Task.Name;
            item.Content = Task.Content;
            item.Priorty = Task.Priorty;
            item.TaskDate = Task.TaskDate;

            entity.SaveChanges();
        }

        public void Delete(Task Task)
        {
            entity.Tasks.Remove(Task);
            entity.SaveChanges();
        }

        public List<Task> SelectAll()
        {
            return entity.Tasks.ToList<Task>();
        }

        public Task getSingle(int id)
        {
            return entity.Tasks.Single(x => x.Id == id);

        }
        public void completeTask(Task Task)
        {
            Task item = entity.Tasks.Where(id => id.Id == Task.Id).First();
            item.Status = true;

            entity.SaveChanges();
        }
    }
}