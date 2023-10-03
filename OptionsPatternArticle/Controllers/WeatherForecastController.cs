using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPatternArticle.Configurations;

namespace OptionsPatternArticle.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    private readonly ILogger<WeatherForecastController> _logger;
    //private readonly OptionsConfigurationBase _options;
    private readonly OptionsConfigurationBase _namedOptions1;
    private readonly OptionsConfigurationBase _namedOptions2;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger, 
        //IOptions<OptionsConfigurationBase> options
        IOptionsSnapshot<OptionsConfigurationBase> options
        //IOptionsMonitor<OptionsConfigurationBase> options
    )
    {
        _logger = logger;
        //_options = options.CurrentValue;
        _namedOptions1 = options.Get(OptionsConfigurationBase.NamedOptions1) ?? throw new ArgumentNullException(nameof(options));
        _namedOptions2 = options.Get(OptionsConfigurationBase.NamedOptions2) ?? throw new ArgumentNullException(nameof(options));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    //[HttpGet]
    //[Route("GetOptionsTest")]
    //public string GetOptionsTest()
    //{
    //    return _options.Test1;
    //}

    [HttpGet]
    [Route("GetOptionsNamed1")]
    public string GetOptionsNamed1()
    {
        return _namedOptions1.Test1;
    }

    [HttpGet]
    [Route("GetOptionsNamed2")]
    public string GetOptionsNamed2()
    {
        return _namedOptions2.Test1;
    }
}