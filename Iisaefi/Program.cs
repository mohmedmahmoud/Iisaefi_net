// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();

// // Add API Explorer for collecting endpoint information
// builder.Services.AddEndpointsApiExplorer();

// // Add SwaggerGen for generating Swagger/OpenAPI documentation
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.

// // Enable Swagger and Swagger UI only in development environment
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger(); // Enable middleware to generate Swagger JSON
//     app.UseSwaggerUI(); // Enable middleware to serve Swagger UI
// }

// app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

// app.UseAuthorization(); // Enable authorization middleware

// app.MapControllers(); // Configure routing for controllers

// app.Run(); // Start the application and listen for incoming HTTP requests

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers();

        // Add API Explorer for collecting endpoint information
        builder.Services.AddEndpointsApiExplorer();

        // Add SwaggerGen for generating Swagger/OpenAPI documentation
        builder.Services.AddSwaggerGen();
        // Ajouter le service AppDbContext
        builder.Services.AddDbContext<AppDbContext>();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        var app = builder.Build();
        TestDatabaseConnection(app.Services);

        // Configure the HTTP request pipeline

        // Enable Swagger and Swagger UI only in development environment
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(); // Enable middleware to generate Swagger JSON
            app.UseSwaggerUI(); // Enable middleware to serve Swagger UI
        }

        app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

        app.UseAuthorization(); // Enable authorization middleware

        app.MapControllers(); // Configure routing for controllers

        app.Run(); // Start the application and listen for incoming HTTP requests
    }


    private static void TestDatabaseConnection(IServiceProvider services)
{
    using (var scope = services.CreateScope())
    {
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        try
        {
            var recordCount = dbContext.Users.Count(); // Remplacez `YourEntity` par le nom de votre entité ou table à tester
            Console.WriteLine($"Connected to the database. Total records: {recordCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to the database: {ex.Message}");
        }
    }
}

}


