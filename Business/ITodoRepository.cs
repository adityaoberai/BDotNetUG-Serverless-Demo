using My.Function.Models;

namespace My.Function.Business
{
    public interface ITodoRepository
    {
        List<Todo> GetAll();
        Todo Add(Todo todo);
    }
}