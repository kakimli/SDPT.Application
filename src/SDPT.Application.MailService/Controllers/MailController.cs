//dependencies 
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.Client;
using SDPT.Application.Models;
using GraphQL.Client;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace SDPT.Application.MailService.Controllers
{

    public class ResponseType 
    {
        public HousingType[] housing { get; set; }
    }

    public class HousingType 
    {
        public string email { get; set; }
        public int rooms { get; set; }    
    }

    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> DemandCreated([FromBody] Demand demand)
        {
            Console.WriteLine($"Subscriber received : {demand.Email} {demand.RoomsMin}");

            int roomsMax = demand.RoomsMax;
            int roomsMin = demand.RoomsMin;

            try {
                // search in graphql endpoints and get email list
                // var housingRequest = new GraphQLRequest {
                //     Query = @"
                //     {
                //         housing (
                //         where: {
                //             and: [
                //             { rooms: { gt: " + 0 + @" } },
                //             { rooms: { lt: " + 3 + @"} }
                //             ]
                //         }
                //         ) {
                //             email,
                //             rooms
                //         }
                //     }"
                // };
                var housingRequest = new GraphQLRequest {
                    Query = @"
                        {
                            housing
                            {
                                email,
                                rooms
                            }
                        }"
                };
                var graphQLClient = new GraphQLHttpClient("https://localhost:6001/graphql", new NewtonsoftJsonSerializer());
                
                var graphQLResponse = await graphQLClient.SendQueryAsync<ResponseType>(housingRequest);
                Console.WriteLine(graphQLResponse.Data.housing[0].email);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            // process the email list

            return Ok();
        }
    }
}
