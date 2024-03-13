namespace ServiceA.models;

public record Forecast
{
    public DateOnly ForecastDate { get; set; }
    public int Temperature { get; set; }
}
