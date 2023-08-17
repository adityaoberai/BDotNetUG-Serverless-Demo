using My.Function.Data;
using My.Function.Models;

namespace My.Function.Business
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;

        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public Todo Add(Todo todo)
        {
            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();
            return todo;
        }

        public List<Todo> GetAll()
        {
            return _todoContext.Todos.ToList();
        }
    }
}