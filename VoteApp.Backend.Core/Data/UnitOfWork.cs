using VoteApp.Backend.Commons.Data;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VoteAppDbContext _dbContext;
        private readonly IGenericRepository<Voter, int> _voterRepository;
        private readonly IGenericRepository<Candidate, int> _candidateRepository;
        public UnitOfWork(VoteAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _voterRepository = new GenericRepository<Voter, int>(dbContext);
            _candidateRepository = new GenericRepository<Candidate, int>(dbContext);
        }

        public IGenericRepository<Voter, int> voterRepository => _voterRepository ?? new GenericRepository<Voter, int>(_dbContext);
        public IGenericRepository<Candidate, int> candidateRepository => _candidateRepository ?? new GenericRepository<Candidate, int>(_dbContext);

        public async Task<bool> Complete(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync(cancellationToken) > 0;

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
