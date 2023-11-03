using VoteApp.Backend.Commons.Entities;

namespace VoteApp.Backend.Core.Data.Entities
{
    public class Vote : EntityBase
    {
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }

        public int VoterId { get; set; }

        public Voter Voter { get; set; }
    }
}
