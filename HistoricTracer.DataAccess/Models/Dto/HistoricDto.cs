using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricTracer.DataAccess.Models.Dto
{
    public class HistoricDto
    {
        public string? Id { get; set; }
        public string? CollaboratorName { get; set; }
        public string? LastAccessed { get; set; }
        public string? CorporateName { get; set; }
        public string Actions { get; set; } = string.Empty;
    }
}
