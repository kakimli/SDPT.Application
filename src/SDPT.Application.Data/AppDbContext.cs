using SDPT.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace SDPT.Application.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Housing> Housings { get; set; }

    public DbSet<Demand> Demands { get; set; }
    
  }
}