using ApiWeather.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiWeather.Context
{
    public class WeatherContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Kaan;initial catalog=ApiWeather;integrated Security=true; TrustServerCertificate=True");
        }

        public DbSet<City> Cities { get; set; }
    }
}
