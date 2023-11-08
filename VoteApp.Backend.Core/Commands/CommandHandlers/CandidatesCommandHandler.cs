using MediatR;
using VoteApp.Backend.Core.Commands.Models;
using VoteApp.Backend.Core.Data.Abstract;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Commands.CommandHandlers
{
    public class CandidatesCommandHandler : IRequestHandler<AddCandidateCommand, Candidate>
    {
        private readonly IGenericRepository<Candidate> _candidateRepository;

        public CandidatesCommandHandler(IGenericRepository<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Candidate> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException(nameof(request));
            }

            var existCandidate = await _candidateRepository.SingleOrDefaultAsync(x => x.Name.ToUpper().Equals(request.Name.ToUpper()), cancellationToken);

            if(existCandidate is not null)
            {
                throw new Exception($"There is a candidate with same name as {request.Name}");
            }

            //todo fluent validation, factory
            var candidate = new Candidate
            {
                Name = request.Name,
            };

            var result = await _candidateRepository.AddAsync(candidate, cancellationToken);
            await _candidateRepository.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
