using Microsoft.EntityFrameworkCore;
using ServiceB.models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ServiceB.data;

public class ForecastContext(DbContextOptions<ForecastContext> options) : DbContext(options)
{
    public virtual DbSet<Forecast> Forecasts { get; set; }
}