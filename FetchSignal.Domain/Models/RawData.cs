using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Enums;

namespace FetchSignal.Domain.Models
{
    public class RawData
    {
        public int Id { get; set; }
        public DateTime FetchedTime { get; set; }= DateTime.UtcNow;
        public DateTime ProcessedStartDate { get; set; }
        public DateTime ProcessedEndDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public Status IsActive { get; set; }
        public int UrlId { get; set; }
        public SourceUrl SourceUrl { get; set; }
        public int FetchedDataId { get; set; }
        public FetchedData FetchedData { get; set; }
    }
}
