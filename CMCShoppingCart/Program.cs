using CMCShoppingCart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .RegisterServices()
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

app.UseAuthorization();

app.MapControllers();

app.Run();
