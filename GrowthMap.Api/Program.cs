
using Microsoft.OpenApi.Models;
using GrowthMap.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TalentGrid API",
        Version = "v1"
    });

});


var app = builder
    .ConfigureService()// Custom extension method to configure application services and persistence
    .ConfigurePipeLine(); // Custom extension method to configure the HTTP request pipeline 

app.Run();
