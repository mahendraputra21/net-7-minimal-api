using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyFristWebApp.@class;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(
    opt => opt.UseInMemoryDatabase("Todos"));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.InferSecuritySchemes();
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme, 
                    Id="Bearer"
                },
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.Configure<SwaggerGeneratorOptions>(options =>
{
    options.InferSecuritySchemes = true;
});

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/", () => "Hello world Guys!");

//to enable Authorization
var todos = app.MapGroup("/todos");
    //.RequireAuthorization();

todos.MapGet("/", (TodoDbContext db) => 
    db.Todos.ToListAsync());

todos.MapPost("/", async (Todo todo, TodoDbContext db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return TypedResults.Created($"/todos/{todo.Id}", todo);
});

todos.MapGet("/{id}", async Task<Results<Ok<Todo>, NotFound>>(int id, TodoDbContext db) =>
    await db.Todos.FindAsync(id) 
        is Todo todo
          ? TypedResults.Ok(todo)
          : TypedResults.NotFound());

todos.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, TodoDbContext db, Todo inputTodo) => 
{
    var todo = await db.Todos.FindAsync(id);
    
    if(todo is null)
        return TypedResults.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsCompleted= inputTodo.IsCompleted;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
});

todos.MapDelete("/{id}", async Task<Results<Ok<Todo>, NotFound>>(int id, TodoDbContext db) => 
{ 
    if(await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return TypedResults.Ok(todo);
    }

    return  TypedResults.NotFound();
});

app.Run();
