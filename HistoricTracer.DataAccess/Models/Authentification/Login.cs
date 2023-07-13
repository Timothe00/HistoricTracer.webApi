using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricTracer.DataAccess.Models.Authentification
{
    public class Login
    {
        [BsonElement("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [BsonElement("PasswordHash")]
        [Required(ErrorMessage = "Password is required")]
        public string? PasswordHash { get; set; } = string.Empty;
    }
}
