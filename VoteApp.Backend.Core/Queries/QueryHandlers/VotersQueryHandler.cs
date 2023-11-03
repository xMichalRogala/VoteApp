using MediatR;
using Microsoft.EntityFrameworkCore;
using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Entities;
using VoteApp.Backend.Core.Queries.Models;

namespace VoteApp.Backend.Core.Queries.QueryHandlers
{
    public class VotersQueryHandler : IRequestHandler<GetAllVotersQuery, IEnumerable<Voter>>
    {
        private readonly IReadGenericRepository<Voter> _voterRepository;

        public VotersQueryHandler(IReadGenericRepository<Voter> voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public async Task<IEnumerable<Voter>> Handle(GetAllVotersQuery request, CancellationToken cancellationToken)
        {
            return await _voterRepository.Get().Include(x => x.Vote).ToListAsync();
        }
    }
}
