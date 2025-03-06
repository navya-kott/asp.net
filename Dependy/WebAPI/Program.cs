using MongoDB.Driver;
using WebAPI;
using WebAPI.Config;
using WebAPI.Middlewares;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB Config

//Bindiing configuration details (in app.settings.json) with the class properties (MongodbConfig class)

var mongoDBConfig = builder.Configuration.GetSection("MongoDB").Get<MongoDbConfig>();


// Dependency injection of MongoDbConfig
builder.Services.AddSingleton<MongoDbConfig>(mongoDBConfig!);


// Mongo Client injected
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoDBConfig!.connectionString));


builder.Services.AddSingleton<MongodbService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton<GlobalExceptionHandlingMw>();

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Verbose()
//    .WriteTo.Console()
//    .WriteTo.File("C:\\Users\\navya\\source\\repos\\Dependency injection\\Dependy\\WebAPI\\Logger\\loggs.txt",
//    rollingInterval: RollingInterval.Minute)
//    .CreateLogger();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.UseMiddleware<GlobalExceptionHandlingMw>();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"Request path{context.Request.Path}");
//    await next(context);
//    Console.WriteLine($"Response {context.Response.StatusCode}");
//});

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
