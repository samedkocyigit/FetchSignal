using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Enums;

namespace FetchSignal.Domain.Models
{
    public class FetchedData
    {
        public int Id { get; set; }
        public string FetchDataString { get; set; }
        public Status IsActive { get; set; }

    }
}
