using Microsoft.AspNetCore.Http.HttpResults;
using MyFristWebApp.@class;
using MyFristWebApp.Features;
using TodoTestProject.Class;

namespace TodoTestProject.Features
{
    public class DeleteTodoTest : GetInMemory
    {
        [Fact]
        public async Task DeleteTodo_ReturnsOk_WhenTodoExists()
        {
            // Arrange
            var db = GetInMemoryDbContext();
            var todo = new Todo { Id = 1, Name = "Test Todo", IsCompleted = false };
            db.Todos.Add(todo);
            await db.SaveChangesAsync();
            var endpoints = new TodoEndpoints(db);

            // Act
            var result = await endpoints.DeleteTodo(1);

            // Assert
            Assert.IsType<Results<Ok<Todo>, NotFound>>(result);
            var dbTodo = await db.Todos.FindAsync(1);
            Assert.Null(dbTodo);
        }


        [Fact]
        public async Task DeleteTodo_ReturnsNotFound_WhenTodoDoesNotExist()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var endpoints = new TodoEndpoints(dbContext);

            // Act
            var result = await endpoints.DeleteTodo(1);

            // Assert
            Assert.IsType<Results<Ok<Todo>, NotFound>>(result);
        }


    }
}