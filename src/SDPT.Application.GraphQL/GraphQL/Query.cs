using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using SDPT.Application.GraphQL.Data;
using SDPT.Application.Models;

namespace SDPT.Application.GraphQL.GraphQL
{
  public class Query
  {
    [UseFiltering]
    public IQueryable<Housing> GetHousing([Service] AppDbContext context)
    {
      return context.Housings;
    }

    // public IQueryable<Housing> QueryHousing([Service] AppDbContext context)
  }
}