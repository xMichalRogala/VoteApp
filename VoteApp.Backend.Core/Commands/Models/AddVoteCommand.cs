using MediatR;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Commands.Models
{
    public class AddVoteCommand : IRequest<Vote>
    {
        public int VoterId { get; set; }

        public int CandidateId { get; set; }
    }
}
