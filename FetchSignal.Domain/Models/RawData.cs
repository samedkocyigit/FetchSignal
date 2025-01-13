using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSignal.Domain.Models
{
    public class RawData
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string FetchedData { get; set; }
        public DateTime FetchedTime { get; set; }= DateTime.UtcNow;
    }
}
