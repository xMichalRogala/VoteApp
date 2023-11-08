using MediatR;
using VoteApp.Backend.Core.Commands.Models;
using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Commands.CommandHandlers
{
    public class VotersCommandHandler : IRequestHandler<AddVoterCommand, Voter>
    {
        private readonly IGenericRepository<Voter> _voterRepository;

        public VotersCommandHandler(IGenericRepository<Voter> voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public async Task<Voter> Handle(AddVoterCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException(nameof(request));
            }

            var existVoter = await _voterRepository.SingleOrDefaultAsync(x => x.Name.ToUpper().Equals(request.Name.ToUpper()), cancellationToken);

            if (existVoter is not null)
            {
                throw new Exception($"There is a voter with same name as {request.Name}");
            }

            //todo fluent validation, factory
            var voter = new Voter
            {
                Name = request.Name,
            };

            var result = await _voterRepository.AddAsync(voter, cancellationToken);
            await _voterRepository.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
