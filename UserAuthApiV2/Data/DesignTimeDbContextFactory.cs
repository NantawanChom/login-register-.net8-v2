using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UserAuthApiV2.Data;
using dotenv.net;

namespace UserAuthApiV2
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Load environment variables (if using DotEnv)
            DotEnv.Load();

            // Retrieve PostgreSQL configuration from environment variables
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
            var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
            var database = Environment.GetEnvironmentVariable("POSTGRES_DB");
            var username = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

            // Construct connection string using environment variables
            var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

            // Set up options for DbContext with PostgreSQL
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseNpgsql(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}