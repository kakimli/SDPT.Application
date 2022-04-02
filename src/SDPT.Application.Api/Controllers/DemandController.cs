//dependencies 
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.Client;
using System.Threading.Tasks;
using System.Threading;
using SDPT.Application.Models;
using SDPT.Application.Data;

class Order {
    public int OrderId { get; set; } = -1;
    public string Summary { get; set; } = String.Empty;
}

class DemandDTO
{

}

namespace SDPT.Application.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DemandController : ControllerBase {

      private readonly DaprClient _daprClient;
      private readonly AppDbContext _context;
      private readonly string PUBSUB_NAME = "eventbus";
      private readonly string TOPIC_NAME = "demand_received";

      public DemandController(
        DaprClient daprClient,
        AppDbContext context) 
      {
          _daprClient = daprClient;
          _context = context;
      }

      private long ConvertToTimestamp(DateTime value)
      {
        DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan elapsedTime = value - Epoch;
        return (long) elapsedTime.TotalSeconds;
      }

      [HttpPost]
      public async Task OnPost(Demand demand) {

        // Add to database
        using (var ctx = _context)
        {
            ctx.Demands.Add(demand);
            ctx.SaveChanges();
        }

        // Publish Event to eventbus
        await _daprClient.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, demand);

      }
  }
}