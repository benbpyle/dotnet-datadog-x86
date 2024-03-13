using Newtonsoft.Json;
using ServiceA.models;
using Datadog.Trace.Annotations;

namespace ServiceA.services;

public class ForecastService(HttpClient httpClient) : IForecastService
{
    [Trace(OperationName = "Get Forecasts", ResourceName = "ForecastService.GetForecasts")]
    public async Task<IEnumerable<Forecast>?> GetForecasts(int cityId)
    {
        var response = await httpClient.GetStringAsync($"api/Forecast/{cityId}");
        var forecast = JsonConvert.DeserializeObject<IEnumerable<Forecast>>(response);
        return forecast;
    }
}