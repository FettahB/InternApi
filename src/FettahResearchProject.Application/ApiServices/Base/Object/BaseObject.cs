using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FettahResearchProject.Application.ApiServices.Base.Object
{
    public class BaseObject
    {
        public int Id { get; set; }

        public string? CreatedName { get; set; }

        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }

        public string UpdatedName { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        public string? CreatedDateTime { get { return CreatedAt?.AddHours(3).ToString("dd.MM.yyyy HH:mm:ss"); } }
        public string? UpdatedDateTime { get { return UpdatedAt?.AddHours(3).ToString("dd.MM.yyyy HH:mm:ss"); } }

    }
}
