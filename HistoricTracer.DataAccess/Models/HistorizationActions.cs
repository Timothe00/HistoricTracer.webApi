using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections;
using System;

namespace HistoricTracer.DataAccess.Models
{
    public class HistorizationActions
    {
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("CollaboratorName")]
        public string? CollaboratorName { get; set; }

        [BsonElement("LastAccessed")]
        public string? LastAccessed { get; set; }
        
        [BsonElement("CorporateName")]
        public string? CorporateName { get; set; }

        [BsonElement("Actions")]
        public string Actions { get; set; } =string.Empty;
    }
}
