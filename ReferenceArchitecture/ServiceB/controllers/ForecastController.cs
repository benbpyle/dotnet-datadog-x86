using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceB.data;
using ServiceB.models;
using Datadog.Trace;
using Datadog.Trace.Annotations;

namespace ServiceB.controllers;

[ApiController]
[Route("api/[controller]")]
public class ForecastController(ForecastContext c) : ControllerBase
{
    // GET
    [HttpGet("{cityId}")]
    [Trace(OperationName = "Get Forecasts", ResourceName = "ForecastController.Get")]
    public ActionResult<IEnumerable<Forecast>> Get([FromRoute(Name = "cityId")] int cityId)
    {
        var forecasts = c.Forecasts.FromSqlRaw("select * from forecasts where CityId = {0}", cityId).ToList();

        using var scope = Tracer.Instance.StartActive("limit 7 forecasts");
        Thread.Sleep(250);
        
        scope.Span.ResourceName = "ForecastController.Get";
        scope.Span.SetTag("CityId", cityId);
        scope.Span.SetTag("SpanKind", "internal");
        if (forecasts.Count < 7)
        {
            return forecasts;
        }

        return forecasts.Take(Range.StartAt(forecasts.Count - 7)).ToList();
    }

}