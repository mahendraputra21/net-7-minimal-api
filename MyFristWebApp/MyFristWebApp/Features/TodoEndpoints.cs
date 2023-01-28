using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyFristWebApp.@class;

namespace MyFristWebApp.Features
{
    public class TodoEndpoints
    {
        private readonly TodoDbContext _db;

        public TodoEndpoints(TodoDbContext db)
        {
            _db = db;
        }

        public async Task<Results<Ok<Todo>, NotFound>> GetTodo(int id)
        {
            if (await _db.Todos.FindAsync(id) is Todo todo)
                return TypedResults.Ok(todo);

            return TypedResults.NotFound();
        }
        public async Task<Results<Created<Todo>, NotFound>> AddTodo(Todo todo)
        {
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
            return TypedResults.Created($"/todos/{todo.Id}", todo);
        }
        public async Task<Results<NotFound, NoContent>> UpdateTodo(int id, Todo inputTodo)
        {
            var todo = await _db.Todos.FindAsync(id);

            if (todo is null)
                return TypedResults.NotFound();

            todo.Name = inputTodo.Name;
            todo.IsCompleted = inputTodo.IsCompleted;

            await _db.SaveChangesAsync();

            return TypedResults.NoContent();
        }
        public async Task<Results<Ok<Todo>, NotFound>> DeleteTodo(int id)
        {
            if (await _db.Todos.FindAsync(id) is Todo todo)
            {
                _db.Todos.Remove(todo);
                await _db.SaveChangesAsync();
                return TypedResults.Ok(todo);
            }

            return TypedResults.NotFound();
        }

        public void MapEndpoints(WebApplication? app)
        {
            var todos = app?.MapGroup("/todos");
            //.RequireAuthorization();

            todos?.MapGet("/", () => _db.Todos.ToListAsync());

            todos?.MapPost("/", AddTodo);

            todos?.MapGet("/{id}", GetTodo);

            todos?.MapPut("/{id}", async (int id, Todo inputTodo) => await UpdateTodo(id, inputTodo));

            todos?.MapDelete("/{id}", DeleteTodo);

        }

    }
}
