using MongoDB.Driver;
using MotoRentalApp.Models;
using Microsoft.Extensions.Configuration;
    

namespace MotoRentalApp.Data;
public class MotorcycleContext
{
    private readonly IMongoDatabase _database;

    public MotorcycleContext(IConfiguration configuration)
    {
        var connectionString = 
            configuration.GetSection("MongoDB:ConnectionString").Value;
        var databaseName =
            configuration.GetSection("MongoDB:DatabaseName").Value;
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
        
    }
    
    public IMongoCollection<Motorcycle> Motorcycles => _database.GetCollection<Motorcycle>("Motorcycles");
    
}
