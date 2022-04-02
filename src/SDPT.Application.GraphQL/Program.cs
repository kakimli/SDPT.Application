using Microsoft.EntityFrameworkCore;
using SDPT.Application.Data;
using SDPT.Application.Data.Migrations;
using SDPT.Application.GraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("SdptConStr"),
    options => options.MigrationsAssembly(typeof(ApplicationsContextFactory).Assembly.FullName)
));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapGraphQL();

app.Run();
