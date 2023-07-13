using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricTracer.DataAccess.Models
{
    [BsonIgnoreExtraElements]
    public class Collaborators
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? CollaboratorId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("UserId")]
        public string UsersId { get; set; } = string.Empty;

        [BsonElement("LastName")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [BsonElement("Profil")]
        public string Profil { get; set; } = string.Empty;
    }
}
