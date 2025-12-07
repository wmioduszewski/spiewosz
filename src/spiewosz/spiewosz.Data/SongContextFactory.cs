using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace spiewosz.Data
{
    public class SongContextFactory : IDesignTimeDbContextFactory<SongContext>
    {
        public SongContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SongContext>();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
            var basePath = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                // also look into the WebApp folder when running from solution root or data project
                .AddJsonFile(Path.Combine("spiewosz.WebApp", "appsettings.json"), optional: true)
                .AddJsonFile(Path.Combine("spiewosz.WebApp", $"appsettings.{env}.json"), optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Songs")
                ?? throw new InvalidOperationException("Connection string 'Songs' not found in appsettings.");

            optionsBuilder.UseNpgsql(connectionString);
            return new SongContext(optionsBuilder.Options);
        }
    }
}
