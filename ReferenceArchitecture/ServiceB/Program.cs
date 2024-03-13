
using Microsoft.EntityFrameworkCore;
using ServiceB.data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ForecastContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForecastContext")));

builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.UseCors();
app.MapControllers();
app.Run();
