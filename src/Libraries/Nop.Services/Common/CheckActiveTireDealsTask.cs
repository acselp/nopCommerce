using Nop.Services.ScheduleTasks;
using Nop.Services.TireDeals;

namespace Nop.Services.Common
{
    public partial class CheckActiveTireDealsTask : IScheduleTask
    {
        private readonly ITireDealService _tireDealService;

        public CheckActiveTireDealsTask(ITireDealService tireDealService)
        {
            _tireDealService = tireDealService;
        }

        public async System.Threading.Tasks.Task ExecuteAsync()
        {
            await _tireDealService.DeactivateExpiredTireDeals();

        }
    }
}