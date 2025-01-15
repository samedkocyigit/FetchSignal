using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;

namespace FetchSignal.Domain.Dtos
{
    public class RawDataDto
    {
        public int Id { get; set; }
        public int UrlId { get; set; }
        public int FetchedDataId { get; set; }
        public DateTime FetchedTime { get; set; }
        public DateTime ProcessedStartDate { get; set; }
        public DateTime ProcessedEndDate { get; set; }
        public SourceUrlDto SourceUrl { get; set; }
        public FetchedData FetchedData { get; set; }
    }
}
