using Hangfire;

namespace FetchSignal.Application.Services.BackgroundJobs
{
    public class RecurringJobs
    {
        private readonly RecurringJobService _service;

        public RecurringJobs(RecurringJobService service)
        {
            _service = service;
        }

        public async Task ExecuteAsync()
        {
            await _service.CallApiEndpointAsync();
        }
    }
}
