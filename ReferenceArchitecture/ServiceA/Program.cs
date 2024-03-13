using ServiceA.services;

var builder = WebApplication.CreateBuilder(args);


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

