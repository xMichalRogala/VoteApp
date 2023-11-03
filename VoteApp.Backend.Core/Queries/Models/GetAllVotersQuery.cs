using MediatR;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Queries.Models
{
    public class GetAllVotersQuery : IRequest<IEnumerable<Voter>>
    {
    }
}
