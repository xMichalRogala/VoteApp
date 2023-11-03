using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VoteAppDbContext _dbContext;
        private readonly IGenericRepository<Voter> _voterRepository;
        private readonly IGenericRepository<Candidate> _candidateRepository;
        public UnitOfWork(VoteAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _voterRepository = new GenericRepository<Voter>(dbContext);
            _candidateRepository = new GenericRepository<Candidate>(dbContext);
        }

        public IGenericRepository<Voter> voterRepository => _voterRepository ?? new GenericRepository<Voter>(_dbContext);
        public IGenericRepository<Candidate> candidateRepository => _candidateRepository ?? new GenericRepository<Candidate>(_dbContext);

        public async Task<bool> Complete(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync(cancellationToken) > 0;

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
