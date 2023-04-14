using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using MyFristWebApp.@class;
using MyFristWebApp.Features;
using TodoTestProject.Class;

namespace TodoTestProject.Features
{
    public class GetTodoTest :GetInMemory
    {
        [Fact]
        public async void GetTodo_ReturnsOk_WhenTodoExists()
        {
            // Arrange
            var db = GetInMemoryDbContext();
            var todo = new Todo { Name = "Test Todo1", IsCompleted = false };
            db.Todos.Add(todo);
            db.SaveChanges();
            var endpoints = new TodoEndpoints(db);

            // Act
            var result = await endpoints.GetTodo(1);
            var actual = ((Ok<Todo>)result.Result).Value;

            // Assert
            Assert.IsType<Results<Ok<Todo>, NotFound>>(result);
            Assert.Equal(todo, actual);

        }

        [Fact]
        public async void GetTodo_ReturnsNotFound_WhenTodoDoesNotExist()
        {
            // Arrange
            var db = GetInMemoryDbContext();
            var endpoints = new TodoEndpoints(db);

            // Act
            var result = await endpoints.GetTodo(9);

            // Assert
            Assert.IsType<Results<Ok<Todo>, NotFound>>(result);
           
        }

    }
}
