using MediatR;
using Microsoft.EntityFrameworkCore;
using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Entities;
using VoteApp.Backend.Core.Queries.Models;

namespace VoteApp.Backend.Core.Queries.QueryHandlers
{
    public class CandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<Candidate>>
    {
        private readonly IReadGenericRepository<Candidate> _candidateRepository;

        public CandidatesQueryHandler(IReadGenericRepository<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IEnumerable<Candidate>> Handle(GetAllCandidatesQuery query, CancellationToken cancellationToken)
        {
            return await _candidateRepository.Get()
                .Include(x => x.Votes)
                .ToListAsync();
        }
    }
}
