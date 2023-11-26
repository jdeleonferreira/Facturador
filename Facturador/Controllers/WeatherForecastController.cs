using Microsoft.AspNetCore.Mvc;

namespace Facturador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            var f = new Invoice();

            var item = new Item();
            item.Cantidad = 2f;
            item.NombreItem = "Tal cual";
            item.ValorUnitario = 5.90f;
            item.ValorTotalItem = item.Cantidad * item.ValorUnitario;

            f.Items.Add(new Item { Cantidad= 5, NombreItem = "Algo", ValorUnitario =3.5f, ValorTotalItem = 0});
            f.Items.Add(item);
            


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
