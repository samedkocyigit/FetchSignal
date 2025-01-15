using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSignal.Domain.Dtos
{
    public class ListOfUrlsDto
    {
        public int Id { get; set; } 
        public string Url { get; set; }
        public string Extension { get; set; }
        public string ApplicationName { get; set; }
    }
}
