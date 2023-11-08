using MediatR;
using Microsoft.EntityFrameworkCore;
using VoteApp.Backend.Core.Commands.Models;
using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Commands.CommandHandlers
{
    public class VotesCommandHandler : IRequestHandler<AddVoteCommand, Vote>
    {
        private readonly IGenericRepository<Vote> _voteRepository;

        public VotesCommandHandler(IGenericRepository<Vote> voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public async Task<Vote> Handle(AddVoteCommand request, CancellationToken cancellationToken)
        {
            var tryGetVoteForVoter = await _voteRepository
                .WhereAsQueryable(x => x.VoterId == request.VoterId)
                .Include(x => x.Voter)
                .SingleOrDefaultAsync(cancellationToken);

            if(tryGetVoteForVoter is not null)
            {
                throw new Exception($"Voter {tryGetVoteForVoter.Voter.Name} has voted already!");
            }

            var result = await _voteRepository.AddAsync(new Vote
            {
                CandidateId = request.CandidateId,
                VoterId = request.VoterId,
            }, cancellationToken);

            await _voteRepository.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
