using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Core.Data.Seeds
{
    public abstract class VoterSeed
    {
        public static IEnumerable<Voter> Voters => CreateVoters();

        private static IEnumerable<Voter> CreateVoters()
        {
            return new List<Voter>()
            {
                new Voter
                {
                    Id = 1,
                    Name = "Alpha",
                },
                new Voter
                {
                    Id = 2,
                    Name = "Charlie",
                },
                new Voter
                {
                    Id = 3,
                    Name = "Beta",
                },
                new Voter
                {
                    Id = 4,
                    Name = "Delta",
                },
                new Voter
                {
                    Id = 5,
                    Name = "Omega",
                }
            };
        }


    }
}
