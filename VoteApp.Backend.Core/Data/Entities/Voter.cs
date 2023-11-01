using VoteApp.Backend.Commons.Entities;
using VoteApp.Backend.CQRS.Events.Abstract;

namespace VoteApp.Backend.Core.Data.Entities
{
    public class Voter : AggregateRoot, IEntityBase<int>
    {
        public int Id { get; set; }

        public bool HasVoted => Vote is not null;

        public string Name { get; set; } = string.Empty;

        public Vote Vote { get; set; }
    }
}
