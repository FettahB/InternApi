using InternApi.Database.Seed;
using InternApi.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;


namespace InternApi.Database.Context
{
    public class MyDbContext : DbContext
    {
        static readonly string connectionString = "Server=db; User ID=fettahbasdemir; Password=fettahbasdemir; Database=MyDatabase";
        public MyDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Weather> Weather { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            DatanaInitializer.Seed(builder);
        }
    }
}
