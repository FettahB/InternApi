using InternApi.Database.Seed;
using InternApi.Entities.Entity;
using Microsoft.EntityFrameworkCore;


namespace InternApi.Database.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        DbSet<Weather> Weather { get; set; }
        protected void OnModelCreating(ModelBuilder builder)
        {
            
            DatanaInitializer.Seed(builder);
        }
    }
}
