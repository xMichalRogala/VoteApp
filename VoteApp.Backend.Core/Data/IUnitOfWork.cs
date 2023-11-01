using VoteApp.Backend.Commons.Data;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Voter, int> voterRepository { get; }
        IGenericRepository<Candidate, int> candidateRepository { get; }

        Task<bool> Complete(CancellationToken cancellationToken = default);
    }
}
