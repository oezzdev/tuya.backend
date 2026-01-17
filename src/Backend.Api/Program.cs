using Backend.Api.Shared.Extensions;
using Backend.Domain.Orders;
using Backend.Infrastructure.Shared;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPersistence(builder.Configuration)
    .AddScoped<OrderService>();

builder.Services
    .AddMediator(options => options.Locations = new Assembly[] { Backend.Application.Assembly.Instance });

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend API", Description = "Backend API", Version = "v1" }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.Services.CreateScope().ServiceProvider.GetRequiredService<BackendContext>().Database.EnsureCreated();
    app.UseSwagger(options => options.RouteTemplate = "openapi/{documentName}/openapi.json");

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1/openapi.json", "v1");
        options.RoutePrefix = "openapi";
    });
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();