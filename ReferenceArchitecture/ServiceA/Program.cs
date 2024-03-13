using Microsoft.EntityFrameworkCore;
using ServiceA.data;
using ServiceA.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ForecastContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ForecastContext")));

builder.Services.AddControllers();
builder.Services.AddHttpClient<IForecastService, ForecastService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"] ?? string.Empty);
});
var app = builder.Build();
app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();

