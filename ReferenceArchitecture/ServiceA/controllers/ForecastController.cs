using Microsoft.AspNetCore.Mvc;
using ServiceA.data;
using ServiceA.models;
using ServiceA.services;

namespace ServiceA.controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController(ForecastContext context, IForecastService forecastService) : ControllerBase
    {
        [HttpGet("{cityId}")]
        //[Trace(OperationName = "api.GetForecast", ResourceName = "Handler")]
        public async Task<ActionResult<City>> Get([FromRoute(Name = "cityId")] int cityId)
        {
            var city = context.Cities.Single(x => x.Id == cityId);
            city.Forecasts = await forecastService.GetForecasts(cityId);

            return city;
        }

    }
}