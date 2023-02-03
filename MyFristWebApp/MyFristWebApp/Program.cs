using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyFristWebApp.Features;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// DbContext Configuration
builder.Services.AddDbContext<TodoDbContext>(
    opt => opt.UseInMemoryDatabase("Todos"));
builder.Services.AddEndpointsApiExplorer();

// Add the TodoEndpoints class to the service container
builder.Services.AddTransient<TodoEndpoints>();

// Swagger Configuration
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

//bypass the cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//------------------------------------------------------------------------------------------------

var app = builder.Build();

// Create a new TodoEndpoints instance and pass in the TodoDbContext
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<TodoDbContext>();
    var endpoints = scope.ServiceProvider.GetRequiredService<TodoEndpoints>();
    endpoints.MapEndpoints(app);
}

app.UseSwagger();
app.UseSwaggerUI();

//enable CORS, can be access by another language program
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
