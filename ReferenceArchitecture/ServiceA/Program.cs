using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();

