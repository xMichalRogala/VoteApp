using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Voter> voterRepository { get; }
        IGenericRepository<Candidate> candidateRepository { get; }

        Task<bool> Complete(CancellationToken cancellationToken = default);
    }
}
