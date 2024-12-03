
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MotoRentalApp.Models;


[BsonIgnoreExtraElements]
public class DeliveryMan
{
    
     public string Identifier { get; set; } 
     public string Name { get; set; }
     public string cnpj { get; set; }
     public DateTime birth_date { get; set; }
     public string cnh_number { get; set; }
     public string cnh_type { get; set; }
     public string image_cnh { get; set; }
}