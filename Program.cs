var builder = WebApplication.CreateBuilder(args);
//COMENTAMOS ESTA LA LINEA DE CODIGO DE ABAJO
//builder.Services.AddStackExchangeRedisCache( options => options.Configuration = "localhost:6379" );

//REEMPLAZAMOS ESTA LINEA DE CODIGO DE ABAJO
//builder.Services.AddStackExchangeRedisCache( options => { options.Configuration = "localhost:6379"; options.InstanceName = "App.Redis.Api"; } );

//LA MODIFICAMOS PARA QUE LEA EL HOST DE REDIS DESDE UNA VARIABLE DE ENTORNO (Redis:Configuration):
var redisConfig = builder.Configuration["Redis:Configuration"] ?? "localhost:6379";
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConfig;
    options.InstanceName = "App.Redis.Api";
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
