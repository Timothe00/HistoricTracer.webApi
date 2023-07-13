using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricTracer.DataAccess.Models
{
    [BsonIgnoreExtraElements]
    public class Contract
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("PolicyNumber")]
        public string PolicyNumber { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string IntermediaryId { get; set; } = string.Empty;

        [BsonElement("ContractDate")]
        public DateTime ContractDate { get; set; } = DateTime.MinValue;

        [BsonElement("DueDate")]
        public DateTime DueDate { get; set; } = DateTime.MinValue;
        [BsonElement("EffectDate")]
        public DateTime EffectDate { get; set; } = DateTime.MinValue;
    }
}
