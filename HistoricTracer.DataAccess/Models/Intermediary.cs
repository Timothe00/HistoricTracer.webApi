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
    public class Intermediary
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Collaborators")]
        public ICollection<Collaborators>? Collaborators { get; set; }

        [BsonElement("CorporateName")]
        public string CorporateName { get; set; } = string.Empty;

        [BsonElement("IntermediaryType")]
        public IntermediaryType? ItermediaryType { get; set; } 


    }

}
