using Application;
using Dal;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add application services and data provider
builder.Services.AddApplication();
builder.Services.AddDataProvider(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Techorama2025 API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#if DEBUG
// In debug mode, ensure the database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    // Ensure the database is created 
    dbContext.Database.EnsureCreated();
}
#endif

app.Run();