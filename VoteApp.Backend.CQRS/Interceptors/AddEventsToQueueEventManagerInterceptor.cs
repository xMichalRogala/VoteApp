using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VoteApp.Backend.CQRS.Events.Abstract;
using VoteApp.Backend.CQRS.Events.Concrete;

namespace TemplateApi.Persistence.Interceptors
{
    public sealed class AddEventsToQueueEventManagerInterceptor : SaveChangesInterceptor
    {
        private readonly EventQueueManager _eventQueueManager;
        public AddEventsToQueueEventManagerInterceptor(EventQueueManager eventQueueManager)
        {
            _eventQueueManager = eventQueueManager;
        }
        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync (
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken
            )
        {
            var dbContext = eventData.Context;


            IEnumerable <EntityEntry<AggregateRoot>> entries = dbContext.ChangeTracker.Entries<AggregateRoot>();

            foreach(EntityEntry<AggregateRoot> entry in entries)
            {
                var events = entry.Entity.GetEventsToPublish();

                if (events != null && events.Any())
                {
                    await _eventQueueManager.AddEventsToQueue(events);
                }
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
