using Microsoft.Extensions.Hosting;
using VoteApp.Backend.CQRS.Events.Concrete;

namespace VoteApp.Backend.CQRS.BackgroundServices
{
    public sealed class EventQueueManagerHostedService : BackgroundService
    {
        private readonly EventQueueManager eventQueueManager;

        public EventQueueManagerHostedService(EventQueueManager eventQueueManager)
        {
            this.eventQueueManager = eventQueueManager;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await eventQueueManager.StartWorkAsync(stoppingToken);
        }
    }
}
