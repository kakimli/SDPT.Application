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
    }

    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {

        // public class MatchingConditions 
        // {
        //     public Room
        //     public Boolean HousingWithParking;
        //     public Boolean 
        // }

        private GraphQLRequest BuildRequest(Demand demand) 
        {

            int roomsMax = demand.RoomsMax;
            int roomsMin = demand.RoomsMin;
            long timeEarliest = demand.TimeEarliest;
            long timeLatest = demand.TimeLatest;
            Boolean withParking = demand.WithParking;
            Boolean independentWashroom = demand.IndependentWashroom;
            DemandLivingType dlt = demand.HousingType;
            Boolean allowPets = demand.AllowPets;

            var query =  @"
                {
                    housing (
                    where: {
                        and: [
                        { roomsMin: { lte: " + roomsMax + @" } },
                        { roomsMax: { gte: " + roomsMin + @" } },
                        { availableTimeEarliest: { lte: " + timeEarliest + @" } },
                        { availableTimeLatest: { gte: " + timeLatest   + @" } }, " +
                        (withParking ? @"{ withParking: true }, " : "") +
                        (independentWashroom ? @"{ independentWashroom: true }, " : "") +
                        (dlt != DemandLivingType.All ? @"{ housingType: " + dlt + " }, " : "") +
                        (allowPets ? @"{ allowPets: true }, " : "") +
                        @"]
                    }
                    ) {
                        email
                    }
                }";

            // Console.WriteLine(query);

            var housingRequest = new GraphQLRequest {
                Query = query
            };

            return housingRequest;
        }

        [HttpPost]
        public async Task<IActionResult> DemandCreated([FromBody] Demand demand)
        {
            Console.WriteLine($"Subscriber received : {demand.Email} {demand.RoomsMin}");

            try {
                // search in graphql endpoints and get email list
                var housingRequest = BuildRequest(demand);
                
                var graphQLClient = new GraphQLHttpClient("https://localhost:6001/graphql", new NewtonsoftJsonSerializer());
                
                var graphQLResponse = await graphQLClient.SendQueryAsync<ResponseType>(housingRequest);
                
                // process the email list
                List<string> emails = new List<string>();
                foreach (var housing in graphQLResponse.Data.housing) {
                    emails.Add(housing.email);
                    Console.WriteLine(housing.email);
                }

                // send emails
                // ...

            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            return Ok();
        }
    }
}
