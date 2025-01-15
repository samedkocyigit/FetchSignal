using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Enums;

namespace FetchSignal.Domain.Models
{
    public  class ListOfUrls
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public string ApplicationName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public Status IsActive { get; set; }
    }
}
