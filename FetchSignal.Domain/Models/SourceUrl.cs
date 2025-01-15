using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Enums;

namespace FetchSignal.Domain.Models
{
    public  class SourceUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ApplicationId { get; set; }
        public Status IsActive { get; set; }


        public Application Application { get; set; }
    }
}
