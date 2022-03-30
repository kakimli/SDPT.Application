// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDaprClient();
// builder.Services.AddRazorPages();

// // Add services to the container.
// builder.Services.AddRazorPages();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// // app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// // app.UseCloudEvents();

// app.UseAuthorization();

// app.MapRazorPages();

// app.Run();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddDaprClient();

builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
