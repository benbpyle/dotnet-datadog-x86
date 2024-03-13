using ServiceA.models;

namespace ServiceA.services;

public interface IForecastService
{
    Task<IEnumerable<Forecast>?> GetForecasts(int cityId);
}