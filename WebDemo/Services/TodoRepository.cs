using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using WebDemo.Controllers;

namespace WebDemo.Services
{
    public class TodoRepository : ITodoRepository
    {

        public IEnumerable<Todo> GetAll()
        {
            return DataStore.todos;
        }

        public Todo Get(string id)
        {
            var todo = DataStore.todos.Find(x => x.Id == id);
            if (todo == null)
            {
                throw new Exception("Todo not found");
            }
            return todo;
        }

        public void Add(Todo todo)
        {
            DataStore.todos.Add(todo);
        }


        public IEnumerable<Todo> Update(Todo req)
        {
            var todo = DataStore.todos.Find(x => x.Id == req.Id);
            if (todo == null)
            {
                throw new Exception("Todo not found");
            }

            todo.Id = req.Id;
            todo.Name = req.Name;
            todo.Content = req.Content;
            todo.Priority = req.Priority;
            todo.Status = req.Status;

            return DataStore.todos;
        }

        public Todo Delete(string id)
        {
            var todo = DataStore.todos.Find(x => x.Id == id);
            if (todo == null)
            {
                throw new Exception("Todo not found");
            }

            if (todo.Status != "Done")
            {
                throw new InvalidOperationException("Cant delete....");
            }

            DataStore.todos.Remove(todo);
            return todo;
        }
    }
}
