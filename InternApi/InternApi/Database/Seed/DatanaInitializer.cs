using InternApi.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace InternApi.Database.Seed
{
    public static class DatanaInitializer
    {
        public static void SeedWeather(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>().HasData(
                new Weather() { ID = 1, Name = "Sunny" },
                new Weather() { ID = 2, Name = "Rainy" },
                new Weather() { ID = 3, Name = "Cloudy" },
                new Weather() { ID = 4, Name = "Snowy" },
                new Weather() { ID = 5, Name = "Windy" },
                new Weather() { ID = 6, Name = "Stormy" },
                new Weather() { ID = 7, Name = "Foggy" },
                new Weather() { ID = 8, Name = "Hail" },
                new Weather() { ID = 9, Name = "Sleet" }
                );
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedWeather(modelBuilder);
        }
    }
}
