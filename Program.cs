using System.Reflection;
using Microsoft.OpenApi.Models;
using MotoRentalApp.Data;

var builder = WebApplication.CreateBuilder(args);

//Registrar contexto MongoDB
builder.Services.AddSingleton<MotorcycleContext>();
builder.Services.AddSingleton<DeliveryManContext>();

// Registrar controladores no contêiner de serviços
builder.Services.AddControllers();

// Registrar Swagger (opcional, caso esteja configurando Swagger)
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

// Configurar Swagger no pipeline (opcional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoRental API v1");
    });
}

app.UseHttpsRedirection();

// Mapear os controladores no pipeline
app.MapControllers();

app.Run();