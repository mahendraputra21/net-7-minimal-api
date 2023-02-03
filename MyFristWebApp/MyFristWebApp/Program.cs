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
builder.Services.AddScoped<TodoEndpoints>();

// Swagger Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Todo API",
        Version = "v1",
        Description = "This is a sample Todo List using .NET 7 API",
        TermsOfService = new Uri("https://www.youtube.com/static?template=terms"),
        Contact = new OpenApiContact
        {
            Name = "Developer",
            Email = "mahendraputra21@gmail.com",
            Url = new Uri("https://mail.google.com/")
        },
        License = new OpenApiLicense
        {
            Name= "Apache 2.0",
            Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
        },

    });


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

// Create a new TodoEndpoints instance 
var endpoints = app.Services.CreateScope().ServiceProvider.GetService<TodoEndpoints>();
endpoints?.MapEndpoints(app);

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1");

});

//enable CORS, can be access by another language program
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
