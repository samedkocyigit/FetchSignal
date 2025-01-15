using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FetchSignal.Domain.Enums;

namespace FetchSignal.Domain.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status IsActive { get; set; }    
        [JsonIgnore]
        public ICollection<SourceUrl>? SourceUrls { get; set; }
    }
}
