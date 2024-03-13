using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceA.models;

public class City
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [NotMapped]
    public IEnumerable<Forecast> Forecasts { get; set; }
}