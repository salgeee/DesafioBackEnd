using MotoRentalApp.Data;

var builder = WebApplication.CreateBuilder(args);

//Registrar contexto MongoDB
builder.Services.AddSingleton<MotorcycleContext>();

// Registrar controladores no contêiner de serviços
builder.Services.AddControllers();

// Registrar Swagger (opcional, caso esteja configurando Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger no pipeline (opcional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear os controladores no pipeline
app.MapControllers();

app.Run();