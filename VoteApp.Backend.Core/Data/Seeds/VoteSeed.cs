using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Data.Seeds
{
    public abstract class VoteSeed
    {
        public static IEnumerable<Vote> Votes => CreateVotes();

        private static IEnumerable<Vote> CreateVotes()
        {
            var candidates = CandidateSeed.Candidates.ToList();
            var voters = VoterSeed.Voters.ToList();

            return new List<Vote>()
            {
                new Vote
                {
                    Id = 1,
                    CandidateId = candidates[0].Id,
                    VoterId = voters[0].Id,
                },
                new Vote
                {
                    Id = 2,
                    CandidateId = candidates[0].Id,
                    VoterId = voters[1].Id,
                },
                new Vote
                {
                    Id = 3,
                    CandidateId = candidates[2].Id,
                    VoterId = voters[2].Id,
                },
                new Vote
                {
                    Id = 4,
                    CandidateId = candidates[2].Id,
                    VoterId = voters[3].Id,
                },
                new Vote
                {
                    Id = 5,
                    CandidateId = candidates[4].Id,
                    VoterId = voters[4].Id,
                },
            };
        }
    }
}
