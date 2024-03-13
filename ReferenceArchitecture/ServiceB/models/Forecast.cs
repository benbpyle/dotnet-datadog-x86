namespace ServiceB.models;

public record Forecast(int Id, int CityId, DateOnly ForecastDate, int Temperature)
{
    public int Id { get; set;  } = Id;
    public int CityId { get; set; } = CityId;
    public DateOnly ForecastDate { get; set; } = ForecastDate;
    public int Temperature { get; set; } = Temperature;
}