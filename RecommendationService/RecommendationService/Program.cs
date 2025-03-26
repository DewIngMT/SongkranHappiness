using RecommendationService.Services; // ADD THIS LINE

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer(); // Standard Swagger registration
builder.Services.AddSwaggerGen();         // Standard Swagger registration
builder.Services.AddControllers();
builder.Services.AddScoped<RecommendationLogicService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("null", "http://localhost", "http://localhost:8000", "http://localhost:8080") // อนุญาต Origin ของหน้าเว็บ (ปรับตามจริง)
               .AllowAnyMethod() // อนุญาต HTTP Methods ทั้งหมด (GET, POST, PUT, DELETE, etc.)
               .AllowAnyHeader(); // อนุญาต HTTP Headers ทั้งหมด
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Standard Swagger middleware
    app.UseSwaggerUI(); // Standard Swagger UI middleware
}

app.UseHttpsRedirection();

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

app.UseHttpsRedirection();
app.UseRouting(); // สำคัญ
app.UseCors();    // สำคัญ (ถ้าใช้)
app.UseAuthorization();
app.MapControllers(); // สำคัญ

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}