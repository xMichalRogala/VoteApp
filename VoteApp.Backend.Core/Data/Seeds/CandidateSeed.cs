using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Data.Seeds
{
    public abstract class CandidateSeed
    {
        public static IEnumerable<Candidate> Candidates => CreateCandidates();

        private static IEnumerable<Candidate> CreateCandidates()
        {
            return new List<Candidate>()
            {
                new Candidate
                {
                    Id = 1,
                    Name = "Alpha"
                },
                new Candidate
                {
                    Id = 2,
                    Name = "Charlie"
                },
                new Candidate
                {
                    Id = 3,
                    Name = "Beta"
                },
                new Candidate
                {
                    Id = 4,
                    Name = "Delta"
                },
                new Candidate
                {
                    Id = 5,
                    Name = "Omega"
                }
            };
        }


    }
}
