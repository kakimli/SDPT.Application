using SDPT.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace SDPT.Application.GraphQL.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Housing> Housings { get; set; }
    
  }
}