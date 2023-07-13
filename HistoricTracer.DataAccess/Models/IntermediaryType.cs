using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HistoricTracer.DataAccess.Models
{
    [BsonIgnoreExtraElements]
    public class IntermediaryType
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
    }
}
