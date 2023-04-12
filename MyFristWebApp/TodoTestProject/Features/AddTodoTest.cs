using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyFristWebApp.@class;
using MyFristWebApp.Features;
using TodoTestProject.Class;

namespace TodoTestProject.Features
{
    public class AddTodoTest : GetInMemory
    {
        //[Fact]
        //public async Task AddTodo_WithValidTodo_ReturnsCreated()
        //{
        //    // Arrange
        //    var db = GetInMemoryDbContext();
        //    var endpoints = new TodoEndpoints(db);
        //    var todo = new Todo { Name = "Test Todo", IsCompleted = false };

        //    // Act
        //    var result = await endpoints.AddTodo(todo);
        //    var actual = ((Created<Todo>)result.Result).Value;

        //    // Assert
        //    Assert.IsType<Results<Created<Todo>, NotFound>>(result);
        //    Assert.Equal(1, await db.Todos.CountAsync());
        //    Assert.Equal(todo, actual);

        //}

    }
}
