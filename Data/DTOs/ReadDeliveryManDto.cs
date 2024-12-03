namespace MotoRentalApp.Data.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ReadDeliveryManDto
{
    public string Identifier { get; set; } 
    public string Name { get; set; }
    public string cnpj { get; set; }
    public DateTime birth_date { get; set; }
    public string cnh_number { get; set; }
    public string cnh_type { get; set; }
    public string image_cnh { get; set; }

}