using Dependency_Injection_DP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the WeatherForecastService with the DI container
// the DI in .net have container responsible of create new instance from any object that defficult to create it
// and also you can define the life time of the instance, it can be singleton, scoped or transient 

// AddTransient: the instance will be created each time it's requested, any time need to use it will create new instance
//builder.Services.AddTransient<WeatherForecastService>();
// AddScoped: the instance will be created once per request, any time need to use it will use the same instance created for this request 
//builder.Services.AddScoped<WeatherForecastService>();
// AddSingleton: the instance will be created once and shared for all requests
//builder.Services.AddSingleton<WeatherForecastService>();

// this before implement the IWeatherForecastService
builder.Services.AddScoped<WeatherForecastService>();
// this after implement the IWeatherForecastService
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
