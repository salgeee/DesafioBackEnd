using System.Reflection;
using Microsoft.OpenApi.Models;
using MotoRentalApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MotorcycleContext>();
builder.Services.AddSingleton<DeliveryManContext>();
builder.Services.AddSingleton<LocationContext>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MotoRental API",
        Version = "v1",
        Description = "API para gerenciamento de motocicletas."
    });
    
    options.OperationFilter<SwaggerResponseExamplesFilter>();

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoRental API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();