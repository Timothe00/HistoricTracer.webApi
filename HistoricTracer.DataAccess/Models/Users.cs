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
    public class Users
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("UserName")]
        public string UserName { get; set; } = string.Empty;

        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; } = string.Empty;

        [BsonElement("LastAccessed")]
        public DateTime LastAccessed { get; set; }

        
    }

    //[BsonElement("CurrentAcced")]
    //public DateOnly CurrentAcced { get; set; }
}
