
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MotoRentalApp.Models;


[BsonIgnoreExtraElements]
public class Motorcycle
{
     public string Identifier { get; set; } 
      public int Year { get; set; }
    
     public string Model { get; set; }
    
    public string Plate { get; set; }
}