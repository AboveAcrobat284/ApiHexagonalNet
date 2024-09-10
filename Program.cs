using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ApiHexagonalNet.Domain.Settings;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Adapters.Out.Persistence.MongoDB;
using ApiHexagonalNet.Application.Services; // Asegúrate de tener este using correcto
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

// Configuración de logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Trace);

// Configuración de MongoDB
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection(nameof(MongoDBSettings)));

builder.Services.AddSingleton<IMongoClient>(s =>
{
    var settings = s.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);

    var logger = s.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Conexión a MongoDB establecida.");

    return client;
});

// Registrar servicios de repositorio
builder.Services.AddScoped<IFlowerRepository, MongoDBFlowerRepository>();
builder.Services.AddScoped<IOrderRepository, MongoDBOrderRepository>();
builder.Services.AddScoped<IFlowerService, FlowerService>();
builder.Services.AddScoped<IOrderService, OrderService>();


// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Log para confirmar que la aplicación ha iniciado correctamente
app.Logger.LogInformation("Aplicación iniciada y escuchando en los puertos configurados...");

try
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogError(ex, "La aplicación falló inesperadamente.");
}
