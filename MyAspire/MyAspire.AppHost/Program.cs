using Aspire.Hosting;
using System.Diagnostics;

var builder = DistributedApplication.CreateBuilder(args);

// Add services to the container.
var mysql = builder.AddSqlServer("MySqlServer");

var apiService = builder.AddProject<Projects.Techorama2025>("Api");

apiService
    .WithReference(mysql, "DefaultConnection")
    // Makes it possible to open the Swagger UI documentation in the aspire dashboard for demo purposes.
    .WithCommand("swagger-ui-docs", "Swagger UI Documentation", async _ =>
    {
        try
        {
            var endpoint = apiService.GetEndpoint("https");
            var url = $"{endpoint.Url}/swagger";

            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            return new ExecuteCommandResult { Success = true };
        }
        catch (Exception e)
        {
            return new ExecuteCommandResult { Success = false, ErrorMessage = e.Message };
            throw;
        }
    });

builder.Build().Run();
