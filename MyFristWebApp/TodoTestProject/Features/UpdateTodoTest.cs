using Microsoft.AspNetCore.Http.HttpResults;
using MyFristWebApp.@class;
using MyFristWebApp.Features;
using TodoTestProject.Class;

namespace TodoTestProject.Features
{
    public class UpdateTodoTest : GetInMemory
    {
        [Fact]
        public async Task UpdateTodo_UpdatesTodo_WhenTodoExists()
        {
            // Arrange
            var db = GetInMemoryDbContext();
            var todo = new Todo { Id = 2, Name = "Test Todo 1", IsCompleted = false };
            db.Todos.Add(todo);
            await db.SaveChangesAsync();
            var endpoints = new TodoEndpoints(db);

            // Act
            var result = await endpoints.UpdateTodo(1, new Todo { Name = "Updated Todo", IsCompleted = true });

            // Assert
            var noContentResult = Assert.IsType<Results<NotFound, NoContent>>(result);
            //Assert.Equal(typeof(NoContent), noContentResult.Value.GetType());
            Assert.True(db.Todos.FindAsync(1).IsCompleted);
  
        }

        [Fact]
        public async Task UpdateTodo_ReturnsNotFound_WhenTodoDoesNotExist()
        {
            // Arrange
            var db = GetInMemoryDbContext();
            var nonExistentTodoId = 1;
            var inputTodo = new Todo { Name = "Updated name", IsCompleted = true };
            var endpoints = new TodoEndpoints(db);

            // Act
            var result = await endpoints.UpdateTodo(nonExistentTodoId, inputTodo);

            // Assert
            Assert.IsType<Results<NotFound, NoContent>>(result);
        }


    }
}
