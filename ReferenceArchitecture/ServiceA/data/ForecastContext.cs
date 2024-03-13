using Microsoft.EntityFrameworkCore;
using ServiceA.models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ServiceA.data
{
    public class ForecastContext(DbContextOptions<ForecastContext> options) : DbContext(options)
    {
        public virtual DbSet<City> Cities { get; set; }
    }
}