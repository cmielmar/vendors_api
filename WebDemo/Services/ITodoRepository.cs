using TodoApp.Models;

namespace WebDemo.Services
{
    public interface ITodoRepository
    {
        void Add(Todo todo);
        Todo Delete(string id);
        Todo Get(string id);
        IEnumerable<Todo> GetAll();
        IEnumerable<Todo> Update(Todo req);
    }
}