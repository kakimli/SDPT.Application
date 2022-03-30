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

      [HttpPost]
      public async Task OnPost() {
          string PUBSUB_NAME = "eventbus";
          string TOPIC_NAME = "demand_received";
          for (int i = 0; i < 1; i++) {
            var data = new Demand { 
              Id = 1,
              Email = "demand1@gmail.com",
              RoomsMax = 3,
              RoomsMin = 1
            };
            //Using Dapr SDK to publish a topic
            await _daprClient.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, data);
            Console.WriteLine("Published data: " + data.Email + data.RoomsMin);
          }
          
      }
  }
}