using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceA.models;

public class City(IEnumerable<Forecast> forecasts, int id, string? name)
{
    public int Id { get; set; } = id;
    public string? Name { get; set; } = name;

    [NotMapped]
    public IEnumerable<Forecast> Forecasts { get; set; } = forecasts;
}