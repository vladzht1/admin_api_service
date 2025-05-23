using System.Collections;
using API.Repositories;
using API.Services;
using API.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<UserRepository, UserRepository>();
builder.Services.AddSingleton<ProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Error: {exception.Message}");
        Console.WriteLine(exception);

        var response = new Hashtable
        {
            ["message"] = exception.Message
        };

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(response);

        return;
    }
});


app.MapControllers();
app.Run();
