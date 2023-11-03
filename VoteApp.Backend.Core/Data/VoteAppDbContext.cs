using Microsoft.EntityFrameworkCore;
using VoteApp.Backend.Core.Data.Entities;
using VoteApp.Backend.Core.Data.Entities.Configurations;

namespace VoteApp.Backend.Core.Data
{
    public class VoteAppDbContext : DbContext
    {
        public VoteAppDbContext(DbContextOptions<VoteAppDbContext> options) : base(options)
        {

        }

        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new VoterConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());
        }
    }
}
