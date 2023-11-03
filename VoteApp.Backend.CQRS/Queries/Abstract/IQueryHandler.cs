namespace VoteApp.Backend.CQRS.Queries.Abstract
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        public Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
