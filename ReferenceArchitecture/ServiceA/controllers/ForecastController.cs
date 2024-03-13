using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceA.models;

namespace ServiceA.controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController() : ControllerBase
    {
        [HttpGet("{cityId}")]
        //[Trace(OperationName = "api.GetForecast", ResourceName = "Handler")]
        public Task<ActionResult<City>> Get([FromRoute(Name = "cityId")] int cityId)
        {
            var forecast = new Forecast()
            {
                Temperature = 73,
                ForecastDate = new DateOnly(2024, 1, 1)
            };

            var city = new City(forecasts: new List<Forecast>() { forecast }, id: 1, name: "Trophy Club");

            return Task.FromResult<ActionResult<City>>(city);
        }

    }
}