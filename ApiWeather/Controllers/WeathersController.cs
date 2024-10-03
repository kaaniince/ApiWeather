using ApiWeather.Context;
using ApiWeather.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values = context.Cities.ToList();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateWeather(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("City is added.");
        }
        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("City is deleted.");
        }
        [HttpPut]
        public IActionResult UpdateWeatherCity(City city)
        {
            var value = context.Cities.Find(city.CityId);
            value.CityName = city.CityName;
            value.Temp = city.Temp;
            value.Country = city.Country;
            value.Detail = city.Detail;
            context.SaveChanges();
            return Ok("City is updated.");
        }

        [HttpGet("GetByIdWeatherCity")]
        public IActionResult GetByIdWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            return Ok(value);
        }
        [HttpGet("TotalCityCount")]
        public  IActionResult TotalCityCount()
        {
            var values = context.Cities.Count();
            return Ok(values);
        }
        [HttpGet("MaxTempCityName")]
        public IActionResult MaxTempCityName()
        {
            var value=context.Cities.OrderByDescending(x => x.Temp).Select(y=>y.CityName).FirstOrDefault();
            return Ok(value);
        }

        [HttpGet("MinTempCityName")]
        public IActionResult MinTempCityName()
        {
            var value = context.Cities.OrderBy(x => x.Temp).Select(y => y.CityName).FirstOrDefault();
            return Ok(value);
        }

    }
}



