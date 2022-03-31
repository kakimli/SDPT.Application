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

class Order {
    public int OrderId { get; set; } = -1;
    public string Summary { get; set; } = String.Empty;
}

namespace SDPT.Application.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DemandController : ControllerBase {
      private readonly DaprClient _daprClient;

      public DemandController(DaprClient daprClient) {
          _daprClient = daprClient;
      }

      private long ConvertToTimestamp(DateTime value)
      {
        DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan elapsedTime = value - Epoch;
        return (long) elapsedTime.TotalSeconds;
      }

      [HttpPost]
      public async Task OnPost() {
        string PUBSUB_NAME = "eventbus";
        string TOPIC_NAME = "demand_received";
        var data = new Demand { 
          Id = 1,
          Email = "demand1@gmail.com",
          RoomsMax = 3,
          RoomsMin = 1,
          TimeEarliest = ConvertToTimestamp(new DateTime(2022, 5, 1, 0, 0, 0, DateTimeKind.Utc)),
          TimeLatest = ConvertToTimestamp(new DateTime(2022, 8, 31, 0, 0, 0, DateTimeKind.Utc))
        };
        Console.WriteLine(data.TimeEarliest);
        Console.WriteLine(data.TimeLatest);
        //Using Dapr SDK to publish a topic
        await _daprClient.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, data);
        // Console.WriteLine("Published data: " + data.Email + data.RoomsMin);
        
        // Add to database

        // Publish Event to eventbus


      }
  }
}