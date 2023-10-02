using ForAirAstana.Domain;
using ForAirAstana.Domain.Services;
using ForAirAstana.Infrastructure;
using ForAirAstana.Infrastructure.Controllers;
using ForAirAstana.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddTransient(typeof(C3Controller<>));
builder.Services.AddTransient<FlightController>();
builder.Services.AddTransient<IFlightService, FlightService>();

builder.Services.AddTransient<FlightList>();

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
