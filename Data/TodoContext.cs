using Microsoft.EntityFrameworkCore;
using My.Function.Models;

namespace My.Function.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}