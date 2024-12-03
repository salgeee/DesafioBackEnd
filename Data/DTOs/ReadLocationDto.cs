namespace MotoRentalApp.Data.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ReadLocationDto
{
    public string Identifier { get; set; }
    public string Id_deliveryman { get; set; }
    public string Id_motor { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
    public DateTime end_forecast_date { get; set; }
    public int plan  { get; set; }

}