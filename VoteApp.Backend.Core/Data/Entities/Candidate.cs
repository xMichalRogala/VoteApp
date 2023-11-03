using VoteApp.Backend.Commons.Entities;

namespace VoteApp.Backend.Core.Data.Entities
{
    public class Candidate : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public int VoteCount => Votes.Count();

        public IList<Vote> Votes { get; set; } = new List<Vote>();
    }
}
