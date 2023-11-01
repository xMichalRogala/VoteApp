using VoteApp.Backend.Commons.Entities;
using VoteApp.Backend.CQRS.Events.Abstract;

namespace VoteApp.Backend.Core.Data.Entities
{
    public class Candidate : AggregateRoot, IEntityBase<int>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IList<Vote> Votes { get; set; } = new List<Vote>();
    }
}
