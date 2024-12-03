using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Location
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Identifier")]
    public string Identifier { get; set; }

    [BsonElement("Id_deliveryman")]
    public string Id_deliveryman { get; set; }

    [BsonElement("Id_motor")]
    public string Id_motor { get; set; }

    [BsonElement("start_date")]
    public DateTime start_date { get; set; }

    [BsonElement("end_date")]
    public DateTime end_date { get; set; }

    [BsonElement("end_forecast_date")]
    public DateTime end_forecast_date { get; set; }

    [BsonElement("plan")]
    public int plan { get; set; }

    [BsonElement("return_date")]
    public DateTime return_date { get; set; }
}