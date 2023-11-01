using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteApp.Backend.Core.Data.Seeds;

namespace VoteApp.Backend.Core.Data.Entities.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable(nameof(VoteAppDbContext.Candidates), Schemas.Core);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Votes)
                .WithOne(v => v.Candidate)
                .HasForeignKey(v => v.CandidateId);

            builder.HasData(CandidateSeed.Candidates);
        }
    }
}
