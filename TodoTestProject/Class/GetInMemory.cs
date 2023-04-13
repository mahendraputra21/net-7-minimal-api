using Microsoft.EntityFrameworkCore;

namespace TodoTestProject.Class
{
    public class GetInMemory
    {
        public static TodoDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TodoDbContext>()
             .UseInMemoryDatabase(databaseName: "Todos")
             .Options;
            var dbContext = new TodoDbContext(options);
            return dbContext;
        }
    }
}