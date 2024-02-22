using NET8_MassTransit_Demo.Controllers;
using MassTransit;
using NET8_MassTransit_Demo.Consumers;

var builder = WebApplication.CreateBuilder(args);


// We will use controllers to create a masstransit demo controller
builder.Services.AddControllers();

// We need to register masstransit service.
// IF you want to send messages every 1 second, you can use the Worker class and uncomment the following line.
//builder.Services.AddHostedService<Worker>();

// We need to initialize masstransit
builder.Services.AddMassTransit( x=>
{
        x.AddConsumers(typeof(Program).Assembly);
        // if you want to use Amazon SQS, Azure Service Bus or RabbitMQ, you just have to change the following line to x.UsingRabbitMQ....
        // ofcourse, first, you need to install the nuget package for that service. ( MassTransit.RabbitMQ ) for example.
        x.UsingInMemory (( context, cfg)  => 
        {
                cfg.ConfigureEndpoints(context);
        });
});

// Add services to the container.
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

app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
