using VoteApp.Backend.Commons.Entities;

namespace VoteApp.Backend.Core.Data.Entities
{
    public class Voter : EntityBase
    {
        public bool HasVoted => Vote is not null;

        public string Name { get; set; } = string.Empty;

        public Vote Vote { get; set; }
    }
}
