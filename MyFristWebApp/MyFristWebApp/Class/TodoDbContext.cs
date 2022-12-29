using Microsoft.EntityFrameworkCore;
using MyFristWebApp.@class;

class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();

}