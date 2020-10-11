using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Appointment_Service.Controllers
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

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        
        //{
        //    //int[] a = new int[3] { 5,1,1};
        //    int index = 2;
        //    int[] a = { 1, 3, 2, 9, 8, 5 };
        //    int[] b = new int[a.Length];
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (i == index)
        //        {
        //            a[i] = a[i + 1];
        //        }
        //        else
        //        {
        //            if (a[i] ==)
        //            {

        //            }
        //        }
                
        //    }
        //    return null;

        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = rng.Next(-20, 55),
        //    //    Summary = Summaries[rng.Next(Summaries.Length)]
        //    //})
        //    //.ToArray();
        //}
    }
}
