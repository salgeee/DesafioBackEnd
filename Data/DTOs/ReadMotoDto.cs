namespace MotoRentalApp.Data.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ReadMotoDto
{
 public string Identifier { get; set; }

    public int Year { get; set; }

    public string Model { get; set; }

    public string Plate { get; set; }
    
    // public DateTime ReadTime { get; set; } = DateTime.Now;
}