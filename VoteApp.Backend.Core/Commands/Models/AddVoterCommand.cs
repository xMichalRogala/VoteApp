using MediatR;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Commands.Models
{
    public class AddVoterCommand : IRequest<Voter>
    {
        public string Name { get; private set; } = string.Empty;

        public AddVoterCommand(string name)
        {
            Name = name;
        }
    }
}
