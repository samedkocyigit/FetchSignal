using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSignal.Application.Services.SignalServices
{
    public interface ISignalService
    {
        Task FetchDataFromUrl(List<string> urls);
    }
}
