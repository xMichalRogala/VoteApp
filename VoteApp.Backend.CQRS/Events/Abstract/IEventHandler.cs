namespace VoteApp.Backend.CQRS.Events.Abstract
{
    public interface IEventHandler<TEvent> : IEvent
    {
        public Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
    }
}
