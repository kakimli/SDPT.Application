using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SDPT.Application.Data.Migrations
{
  public class ApplicationsContextFactory : IDesignTimeDbContextFactory<AppDbContext>
  {
      public AppDbContext CreateDbContext(string[] args)
      {
        // var configurationBuilder = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.Development.json", true, true);
        // var configuration = configurationBuilder.Build();
        // var connectionString = configuration.GetConnectionString("SdptConStr");
        var connectionString = "Server=localhost,1433;Database=SdptDB2;User Id=sa;Password=pa55w0rd!";
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new AppDbContext(optionsBuilder.Options);
      }
  }
}

