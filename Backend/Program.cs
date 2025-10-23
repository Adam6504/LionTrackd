using LionTrackdAPI.Configuration;
using LionTrackdAPI.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB settings
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

// Add MongoDB service
builder.Services.AddSingleton<MongoDBService>();

// Add controllers
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins(
                      "http://localhost:5173",  // Vite dev server
                      "http://localhost:5000")  // Backend port
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Verify MongoDB connection on startup
try
{
    using (var scope = app.Services.CreateScope())
    {
        var mongoService = scope.ServiceProvider.GetRequiredService<MongoDBService>();
        var mongoSettings = scope.ServiceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
        
        Console.WriteLine("=================================================");
        Console.WriteLine("Testing MongoDB Connection...");
        Console.WriteLine($"Database: {mongoSettings.DatabaseName}");
        Console.WriteLine($"Connection String: {mongoSettings.ConnectionString.Substring(0, Math.Min(50, mongoSettings.ConnectionString.Length))}...");
        
        bool isConnected = await mongoService.TestConnectionAsync();
        
        if (isConnected)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✓ MongoDB connection successful!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("✗ MongoDB connection failed!");
            Console.ResetColor();
        }
        Console.WriteLine("=================================================");
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("=================================================");
    Console.WriteLine("✗ MongoDB connection error:");
    Console.WriteLine(ex.Message);
    Console.WriteLine("=================================================");
    Console.ResetColor();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
