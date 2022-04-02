using Microsoft.EntityFrameworkCore;
using SDPT.Application.Data;
using SDPT.Application.Data.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddDaprClient();

builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("SdptConStr"),
    options => options.MigrationsAssembly(typeof(ApplicationsContextFactory).Assembly.FullName)
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCloudEvents();
app.UseAuthorization();
app.MapControllers();
app.MapSubscribeHandler();

app.Run();
